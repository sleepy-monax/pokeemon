import { Injectable } from '@angular/core';
import { Socket } from 'dgram';
import { EMPTY, Subject } from 'rxjs';
import { catchError, tap, switchAll } from 'rxjs/operators';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WebsocketService {
  private ws: WebSocketSubject<any>;
  private messagesSubject = new Subject();

  public messages = this.messagesSubject.pipe(switchAll(), catchError(e => { throw e }));


  constructor() {
  }

  public connect() {
    if (!this.ws || this.ws.closed) {
      this.ws = webSocket(`ws://${environment.serverAddress}:${environment.webSocketPort}`);

      const messages = this.ws.pipe(
        tap({
          error: error => console.log(error),
        }), catchError(_ => EMPTY));

      this.messagesSubject.next(messages);
    }
  }

  public send(msg: any): void {
    this.ws.next(msg);
  }

  public close(): void {
    this.ws.complete();
  }
}

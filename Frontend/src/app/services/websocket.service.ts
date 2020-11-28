import { Injectable } from '@angular/core';
import { EMPTY, Subject } from 'rxjs';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { catchError, tap, switchAll } from 'rxjs/operators';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WebsocketService {
  private socket: WebSocket;
  private messagesSubject = new Subject();

  public messages = this.messagesSubject.pipe(switchAll(), catchError(e => { throw e }));
  public isConnected: BehaviorSubject<boolean> = new BehaviorSubject(false);

  constructor() {
  }

  public connect() {
    const address = `ws://${environment.serverAddress}:${environment.webSocketPort}/${environment.webSocketEndpoint}`;
    console.log(`Connecting to ${address}...`);
    this.socket = new WebSocket(address);

    this.socket.addEventListener("open", (ev => {
      this.isConnected.next(true);
    }));

    this.socket.addEventListener("message", (ev => {
      var message: any = JSON.parse(ev.data);
      console.log(message);
    }));
  }

  public send(msg: any): void {
  }

  public close(): void {
    this.socket.close();
  }
}

import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { catchError, switchAll } from 'rxjs/operators';

import { environment } from 'src/environments/environment';

interface Message {
  type: string;
  payload: any;
}

@Injectable({
  providedIn: 'root'
})
export class WebsocketService {
  private socket: WebSocket;
  private messagesSubject = new Subject();
  private messagesHandlers: { [id: string]: ((msg: Message) => void) } = {};

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
      var message: Message = JSON.parse(ev.data);
      console.log(message);
      this.dispatch(message);
    }));
  }

  private dispatch(message: Message) {
    if (message.type in this.messagesHandlers) {
      this.messagesHandlers[message.type](message)
    } else {
      console.log(`No handler of message of type '${message.type}'`);
    }
  }

  public registerHander<T>(type: string, callback: ((arg: T) => void)) {
    this.messagesHandlers[type] = (message: Message) => {
      callback(message.payload as T);
    };
  }

  public send<T>(type: string, payload: T): void {
    const message = { type, payload };
    this.socket.send(JSON.stringify(message));
  }

  public close(): void {
    this.socket.close();
  }
}

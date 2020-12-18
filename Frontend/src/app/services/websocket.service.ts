import { Injectable, OnInit } from '@angular/core';
import { env } from 'process';
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
  private messagesHandlers: { [id: string]: ((msg: Message) => void) } = {};

  public isConnected: BehaviorSubject<boolean> = new BehaviorSubject(false);

  constructor() {
    this.connect();
  }

  public connect(): void {
    const address = `${environment.webSocketProtocole}://${environment.serverAddress}:${environment.webSocketPort}/${environment.webSocketEndpoint}`;
    console.log(`Connecting to ${address}...`);
    this.socket = new WebSocket(address);

    this.socket.addEventListener('open', (ev => {
      this.isConnected.next(true);
    }));

    this.socket.addEventListener('close', (ev => {
      this.isConnected.next(false);
    }));

    this.socket.addEventListener('message', (ev => {
      const message: Message = JSON.parse(ev.data);
      this.dispatch(message);
    }));
  }

  private dispatch(message: Message): void {
    if (message.type in this.messagesHandlers) {
      this.messagesHandlers[message.type](message)
    } else {
      console.log(`No handler of message of type '${message.type}'`);
      console.log(message);
    }
  }

  public registerHandler<T>(type: string, callback: ((arg: T) => void)): void {
    this.messagesHandlers[type] = (message: Message) => {
      callback(message.payload as T);
    };
  }

  public send<T>(type: string, message: T): void {
    const pkg = { type, message };
    this.socket.send(JSON.stringify(pkg));
  }

  public close(): void {
    this.socket.close();
  }
}

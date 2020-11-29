import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { WebsocketService } from './websocket.service';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private _messages: string[] = [];

  public messages: BehaviorSubject<string[]> = new BehaviorSubject([]);

  constructor(private ws: WebsocketService) {
    ws.registerHandler('chat-message', (resp: string) => {
      this._messages.push(resp);
      this.messages.next(this._messages);
    });
  }

  public send(message: string) {
    this.ws.send('chat-message', { text: message });
  }
}

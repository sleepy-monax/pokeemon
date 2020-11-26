import { Injectable } from '@angular/core';
import { Address } from '../model/battle/address';
import { Properties } from '../model/battle/properties';
import { WebsocketService } from './websocket.service';

@Injectable({
  providedIn: 'root'
})
export class BattleService {
  constructor(private ws: WebsocketService) {
    ws.connect()
  }

  start(props: Properties) {
    this.ws.send({ type: 'create-battle', properties: props });
  }

  join(addr: Address) {
    this.ws.send({ type: 'join-battle', properties: addr });
  }

  quit() {
    this.ws.send({ type: 'quit-battle' });
  }
}

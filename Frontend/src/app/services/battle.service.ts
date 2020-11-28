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

  public start(props: Properties): void {
    this.ws.send('create-battle', props);
  }

  public join(addr: Address): void {
    this.ws.send('join-battle', addr);
  }

  public quit(): void {
    this.ws.send('quit-battle', {});
  }
}

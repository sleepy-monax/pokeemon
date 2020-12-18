import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Address } from '../model/battle/address';
import { Properties } from '../model/battle/properties';
import { WebsocketService } from './websocket.service';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class BattleService {
  public battles: BehaviorSubject<string[]> = new BehaviorSubject([]);

  constructor(private ws: WebsocketService, private http: HttpClient) {
    ws.connect()
  }

  public refreshList(): void {
    this.http.get<string[]>(`https://${environment.serverAddress}:${environment.apiPort}/battles`)
      .pipe(map(battles => {
        this.battles.next(battles);
        return battles;
      }));
  }

  public create(): void {
    this.ws.send('battle-create', {});
  }

  public join(battle_id: Address): void {
    this.ws.send('battle-join', { battle_id });
  }

  public leave(): void {
    this.ws.send('battle-leave', {});
  }

  public attack(attack_name: string): void {
    this.ws.send('battle-attack', { attack_name });
  }

  public use(item: string, target_enemy: boolean, creature_index: number): void {
    this.ws.send('battle-use-item', { item, target_enemy, creature_index });
  }

  public chat(text: string): void {
    this.ws.send("battle-chat", { text });
  }

}

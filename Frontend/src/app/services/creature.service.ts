import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Creature, Creatures} from '../model/creature';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CreatureService {

  private static URL: string = 'https://' + environment.serverAddress + ':' + environment.apiPort + '/creatures';
  constructor(private http: HttpClient) { }

  create(creature: Creature): Observable<Creature> {
    return this.http.post<Creature>(CreatureService.URL, creature);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(CreatureService.URL + '/' + id);
  }

  query(): Observable<Creature> {
    return this.http.get<Creature>(CreatureService.URL);
  }

  update(id: number, creature: Creature): Observable<any> {
    return this.http.put(CreatureService.URL + '/' + id, creature);
  }

  get(idUser: number): Observable<Creatures> {
    return this.http.get<Creatures>(CreatureService.URL + '/user/' + idUser);
  }
}

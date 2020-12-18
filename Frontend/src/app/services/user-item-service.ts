import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {UserItem, UserItems} from '../model/user-item';
import {Observable} from 'rxjs';
import {UserItemRepository} from '../model/user-item-repository';

@Injectable({
  providedIn: 'root'
})
export class UserItemService implements UserItemRepository {
  private static URL: string = 'https://' + environment.serverAddress + ':' + environment.apiPort + '/items';

  constructor(private http: HttpClient) { }

  create(userItem: UserItem): Observable<UserItem> {
    return this.http.post<UserItem>(UserItemService.URL, userItem);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(UserItemService.URL + '/' + id);
  }

  query(): Observable<UserItems> {
    return this.http.get<UserItems>(UserItemService.URL);
  }

  update(id: number, userItem: UserItem): Observable<any> {
    return this.http.put(UserItemService.URL + '/' + id, userItem);
  }

  getById(id: number): Observable<UserItem> {
    return this.http.get<UserItem>(UserItemService.URL + '/' + id);
  }

  getByUser(idUser: number): Observable<UserItems> {
    return this.http.get<UserItems>(UserItemService.URL + '/user/' + idUser);
  }

}

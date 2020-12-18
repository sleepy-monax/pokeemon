import {Observable} from 'rxjs';
import {UserItem, UserItems} from './user-item';

export interface UserItemRepository {

  query(): Observable<UserItems>;
  create(userItem: UserItem): Observable<UserItem>;
  delete(id: number): Observable<any>;
  update(id: number, userItem: UserItem): Observable<any>;
  getById(id: number): Observable<UserItem>;
  getByUser(id: number): Observable<UserItems>;
}

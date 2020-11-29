import {Observable} from 'rxjs';
import {User, Users} from './user';

export interface UserRepository {
  query(): Observable<Users>;
  create(user: User): Observable<User>;
  delete(id: number): Observable<any>;
  update(id: number, user:User): Observable<any>;
  getById(id: number): Observable<User>;
}

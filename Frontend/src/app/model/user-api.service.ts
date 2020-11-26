import {UserRepository} from './user-repository';
import {User, Users} from './user';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserApiService implements UserRepository{
  private static URL: string = environment.serverAddress + 'api/todos';

  constructor(private http: HttpClient) { }

  create(user: User): Observable<User> {
    return this.http.post<User>(UserApiService.URL, user);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(UserApiService.URL + '/' + id);
  }

  query(): Observable<Users> {
    return this.http.get<Users>(UserApiService.URL);
  }

  update(id: number, user: User): Observable<any> {
    return this.http.put(UserApiService.URL + '/' + id, user);
  }
}

import {Injectable} from '@angular/core';
import {UserRepository} from '../model/user-repository';
import {User, Users} from '../model/user';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserApiService implements UserRepository{
  private static URL: string = "https://" + environment.serverAddress +":" + environment.apiPort +"/users";

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

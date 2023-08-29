import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';
import { ReplaySubject } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class AccountService {
  // It's used for making http requests
  baseUrl: string = 'https://localhost:7234/api/';

  private currentUserSource = new ReplaySubject<User>(1);

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
  }
}

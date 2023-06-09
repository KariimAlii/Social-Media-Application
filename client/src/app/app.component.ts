import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Connect People';
  users: any;
  constructor (private http : HttpClient ) {}
  ngOnInit(): void {
    this.getUsers();
  }
  getUsers() {
    this.http.get('https://localhost:7234/api/users')
    .subscribe(response => {
      this.users = response;
    },
    error => {
      console.log(error);
    })
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/User/User';


@Injectable(/*{providedIn: 'root'}*/)
export class UserService {

  constructor(private http: HttpClient) {
  }

  getuser(): Observable<User> {
    return this.http.get<User>(`/user/GetUser`);
  }
  
}

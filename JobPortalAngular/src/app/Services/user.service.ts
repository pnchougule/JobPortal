import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login, Register } from './User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  private baseUrl = 'https://localhost:44351/api/Users'; 

  constructor(private httpClient: HttpClient) { }

  Register(user: Register): Observable<Object> {
    return this.httpClient.post(`${this.baseUrl}/AddUser`, user);
  }

  Login(user: Login): Observable<Object> {
    return this.httpClient.put(`${this.baseUrl}/login`, user);
  }

  UpdateUser(user: Register): Observable<Object> {
    return this.httpClient.put(`${this.baseUrl}/UpdateUser`, user);
  }

  DeleteUser(id: number): Observable<Object> {
    return this.httpClient.delete(`${this.baseUrl}/DeleteUser?id=${id}`);
  }
  
}


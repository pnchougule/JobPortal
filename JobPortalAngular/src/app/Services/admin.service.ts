import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Admin } from './Admin';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private baseUrl = 'https://localhost:44351/api/Admin';  // Adjust to your actual API URL

  constructor(private httpClient: HttpClient) { }

  GetAllAdmins(): Observable<Admin[]> {
    return this.httpClient.get<Admin[]>(`${this.baseUrl}/GetAllAdmins`);
  }

  GetAdminById(adminId: number): Observable<Admin> {
    return this.httpClient.get<Admin>(`${this.baseUrl}/GetAdminById?id=${adminId}`);
  }

  AddAdmin(admin: Admin): Observable<Object> {
    return this.httpClient.post(`${this.baseUrl}/AddAdmin`, admin);
  }

  UpdateAdmin(admin: Admin): Observable<Object> {
    return this.httpClient.put(`${this.baseUrl}/UpdateAdmin`, admin);
  }

  DeleteAdmin(adminId: number): Observable<Object> {
    return this.httpClient.delete(`${this.baseUrl}/DeleteAdmin?id=${adminId}`);
  }
}


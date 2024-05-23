import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from './Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private baseUrl = 'https://localhost:44351/api/Employee';  // Adjust to your actual API URL

  constructor(private httpClient: HttpClient) { }

  GetAllEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(`${this.baseUrl}/GetAllEmployees`);
  }

  GetEmployeeById(empId: number): Observable<Employee> {
    return this.httpClient.get<Employee>(`${this.baseUrl}/GetEmployeeById?id=${empId}`);
  }

  AddEmployee(emp: Employee): Observable<Object> {
    return this.httpClient.post(`${this.baseUrl}/AddEmployee`, emp);
  }

  UpdateEmployee(emp: Employee): Observable<Object> {
    return this.httpClient.put(`${this.baseUrl}/UpdateEmployee`, emp);
  }

  DeleteEmployee(empId: number): Observable<Object> {
    return this.httpClient.delete(`${this.baseUrl}/DeleteEmployeeById?id=${empId}`);
  }
}


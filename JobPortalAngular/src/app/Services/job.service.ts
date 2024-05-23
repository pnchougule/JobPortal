import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Job } from './Job';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private baseUrl = 'https://localhost:44351/api/Jd';  // Adjust to your actual API URL

  constructor(private httpClient: HttpClient) { }

  GetAllJds(): Observable<Job[]> {
    return this.httpClient.get<Job[]>(`${this.baseUrl}/GetAllJds`);
  }

  GetJdById(id: number): Observable<Job> {
    return this.httpClient.get<Job>(`${this.baseUrl}/GetJdById?id=${id}`);
  }

  AddJd(job: Job): Observable<Object> {
    return this.httpClient.post(`${this.baseUrl}/AddJd`, job);
  }

  UpdateJd(job: Job): Observable<Object> {
    return this.httpClient.put(`${this.baseUrl}/UpdateJd`, job);
  }

  DeleteJd(id: number): Observable<Object> {
    return this.httpClient.delete(`${this.baseUrl}/DeleteJd?id=${id}`);
  }
}


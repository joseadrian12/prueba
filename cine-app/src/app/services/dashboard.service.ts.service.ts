import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dashboard } from '../models/dashboard';


@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  private apiUrl = 'https://localhost:7047/api/Dashboard';

  constructor(private http: HttpClient) {}

  obtenerDatos(): Observable<Dashboard> {
    return this.http.get<Dashboard>(this.apiUrl);
  }


}

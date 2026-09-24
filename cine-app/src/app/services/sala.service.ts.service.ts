import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Sala } from '../models/sala';

@Injectable({
  providedIn: 'root'
})
export class SalaService {

  private apiUrl = 'https://localhost:7047/api/Sala';

  constructor(private http: HttpClient) {}

  obtenerSalas(): Observable<Sala[]> {
    return this.http.get<Sala[]>(this.apiUrl);
  }

  crearSala(sala: Sala): Observable<Sala> {
    return this.http.post<Sala>(
      this.apiUrl,
      sala
    );
  }

  actualizarSala(
    id: number,
    sala: Sala
  ): Observable<Sala> {

    return this.http.put<Sala>(
      `${this.apiUrl}/${id}`,
      sala
    );
  }
}
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pelicula } from '../models/pelicula';


@Injectable({
  providedIn: 'root'
})
export class PeliculaService {

  private apiUrl =
    'https://localhost:7047/api/Pelicula';

  constructor(
    private http: HttpClient
  ) {}

  obtenerPeliculas(): Observable<Pelicula[]> {
    return this.http.get<Pelicula[]>(
      this.apiUrl
    );
  }

  crearPelicula(
    pelicula: Pelicula
  ): Observable<Pelicula> {

    return this.http.post<Pelicula>(
      this.apiUrl,
      pelicula
    );
  }

  actualizarPelicula(
    id: number,
    pelicula: Pelicula
  ): Observable<Pelicula> {

    return this.http.put<Pelicula>(
      `${this.apiUrl}/${id}`,
      pelicula
    );
  }

  eliminarPelicula(
    id: number
  ): Observable<string> {

    return this.http.delete(
      `${this.apiUrl}/${id}`,
      {
        responseType: 'text'
      }
    );
  }
}
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import {
  Asignacion,
  AsignacionDetalle
} from '../models/asignacion';

@Injectable({
  providedIn: 'root'
})
export class AsignacionService {

  private apiUrl =
    'https://localhost:7047/api/Asignacion';

  constructor(
    private http: HttpClient
  ) {}


  obtenerAsignaciones(): Observable<AsignacionDetalle[]> {

    return this.http.get<AsignacionDetalle[]>(
      this.apiUrl
    );
  }


  crearAsignacion(
    asignacion: Asignacion
  ): Observable<string> {

    return this.http.post(
      this.apiUrl,
      asignacion,
      {
        responseType: 'text' 
      }
    );
  }

}
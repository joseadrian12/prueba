import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

import {
    LoginRequest,
    LoginResponse
} from '../models/login';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private apiUrl =
        'https://localhost:7047/api/Auth';

    constructor(
        private http: HttpClient
    ) { }

    login(
        usuario: string,
        password: string
    ): Observable<LoginResponse> {

        const datos: LoginRequest = {
            usuario,
            password
        };

        return this.http
            .post<LoginResponse>(
                `${this.apiUrl}/login`,
                datos
            )
            .pipe(
                tap(respuesta => {

                    localStorage.setItem(
                        'token',
                        respuesta.token
                    );

                    localStorage.setItem(
                        'usuario',
                        respuesta.usuario
                    );

                })
            );
    }

    obtenerToken(): string | null {

        return localStorage.getItem('token');

    }

    estaAutenticado(): boolean {

        return this.obtenerToken() != null;

    }

    cerrarSesion(): void {

        localStorage.removeItem('token');
        localStorage.removeItem('usuario');

    }
}
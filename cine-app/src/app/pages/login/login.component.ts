import { Component, signal } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  usuario: string = '';
  password: string = '';

  mensajeError = signal<string>('');
  cargando = signal<boolean>(false);

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  iniciarSesion(): void {

    this.mensajeError.set('');

    if (
      !this.usuario ||
      !this.password
    ) {

      this.mensajeError.set(
        'Debe ingresar usuario y contraseña'
      );

      return;
    }

    this.cargando.set(true);

    this.authService
      .login(
        this.usuario,
        this.password
      )
      .subscribe({

        next: () => {

          this.cargando.set(false);

          this.router.navigate([
            '/dashboard'
          ]);

        },

        error: (error) => {

          console.error(error);

          this.cargando.set(false);

          this.mensajeError.set(
            'Usuario o contraseña incorrectos'
          );

        }

      });
  }
}
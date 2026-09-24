import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  styleUrl: './login.component.scss',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  usuario: string = '';
  password: string = '';
  mensajeError: string = '';

  constructor(private router: Router) { }

  iniciarSesion(): void {

    if (this.usuario === 'admin' && this.password === '1234') {

      localStorage.setItem('usuario', this.usuario);

      this.router.navigate(['/dashboard']);

    } else {

      this.mensajeError = 'Usuario o contraseña incorrectos';

    }
  }


}

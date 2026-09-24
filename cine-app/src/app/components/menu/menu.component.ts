import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  standalone: false,
  styleUrl: './menu.component.scss',
  templateUrl: './menu.component.html',
})
export class MenuComponent {

  constructor(private router: Router) { }

  cerrarSesion(): void {

    localStorage.removeItem('usuario');

    this.router.navigate(['/']);

  }
}


import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-menu',
  standalone: false,
  styleUrl: './menu.component.scss',
  templateUrl: './menu.component.html',
})
export class MenuComponent {

  constructor(private router: Router, private authService : AuthService) { }

  cerrarSesion(): void {

    this.authService
      .cerrarSesion();

    this.router.navigate([
      '/'
    ]);
  }
}


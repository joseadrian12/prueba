import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './pages/login/login.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PeliculasComponent } from './pages/peliculas/peliculas.component';
import { SalasComponent } from './pages/salas/salas.component';
import { AsignacionComponent } from './pages/asignacion/asignacion.component';
import { authGuard } from './pages/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [authGuard]
  },
  {
    path: 'peliculas',
    component: PeliculasComponent,
    canActivate: [authGuard]
  },
  {
    path: 'salas',
    component: SalasComponent,
    canActivate: [authGuard]
  },
  {
    path: 'asignacion',
    component: AsignacionComponent,
    canActivate: [authGuard]
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
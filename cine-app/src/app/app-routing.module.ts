import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './pages/login/login.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PeliculasComponent } from './pages/peliculas/peliculas.component';
import { SalasComponent } from './pages/salas/salas.component';
import { AsignacionComponent } from './pages/asignacion/asignacion.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'peliculas',
    component: PeliculasComponent
  },
  {
    path: 'salas',
    component: SalasComponent
  },
  {
    path: 'asignacion',
    component: AsignacionComponent
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
import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { App } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { AsignacionComponent } from './pages/asignacion/asignacion.component';
import { MenuComponent } from './components/menu/menu.component';
import { SalasComponent } from './pages/salas/salas.component';
import { PeliculasComponent } from './pages/peliculas/peliculas.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { authInterceptor } from './pages/interceptors/auth.interceptor';

@NgModule({
  declarations: [
    App,
    LoginComponent,
    AsignacionComponent,
    MenuComponent,
    SalasComponent,
    PeliculasComponent,
    DashboardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideHttpClient(
      withInterceptors([
        authInterceptor
      ])
    )
  ],
  bootstrap: [App],
  exports: [
    RouterModule
  ]
})
export class AppModule { }

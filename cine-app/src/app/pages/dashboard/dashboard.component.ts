import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Dashboard } from '../../models/dashboard';
import { DashboardService } from '../../services/dashboard.service.ts.service';

@Component({
  selector: 'app-dashboard',
  standalone: false,
  styleUrl: './dashboard.component.scss',
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {

  datos: Dashboard = {
    totalSalas: 0,
    salasDisponibles: 0,
    totalPeliculas: 0
  };

  cargando: boolean = true;
  error: string = '';

  constructor(
    private dashboardService: DashboardService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.obtenerDatos();
  }

  obtenerDatos(): void {

    this.dashboardService.obtenerDatos()
      .subscribe({
        next: (respuesta) => {

          this.datos = respuesta;
          this.cargando = false;

          this.cdr.markForCheck();
        },

        error: (error) => {

          console.error(error);

          this.error = 'No se pudieron cargar los datos';
          this.cargando = false;

          this.cdr.markForCheck();
        }
      });
  }
}
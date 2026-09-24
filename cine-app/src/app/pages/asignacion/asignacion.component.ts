import { Component, OnInit, signal } from '@angular/core';

import { Pelicula } from '../../models/pelicula';
import { Sala } from '../../models/sala';

import {
  Asignacion,
  AsignacionDetalle
} from '../../models/asignacion';

import { PeliculaService } from '../../services/pelicula.service.ts.service';
import { SalaService } from '../../services/sala.service.ts.service';
import { AsignacionService } from '../../services/asignacion.service.ts.service';

@Component({
  selector: 'app-asignacion',
  standalone: false,
  styleUrl: './asignacion.component.scss',
  templateUrl: './asignacion.component.html',
})
export class AsignacionComponent implements OnInit {

  // Listados
peliculas = signal<Pelicula[]>([]);
salas = signal<Sala[]>([]);
asignaciones = signal<AsignacionDetalle[]>([]);

cargando = signal<boolean>(false);
mensaje = signal<string>('');
error = signal<string>('');

  // Control de carga
  peliculasCargadas: boolean = false;
  salasCargadas: boolean = false;
  asignacionesCargadas: boolean = false;

  // Formulario
  idPelicula: number | null = null;
  idSalaCine: number | null = null;

  fechaPublicacion: string = '';
  fechaFin: string = '';

  constructor(
    private peliculaService: PeliculaService,
    private salaService: SalaService,
    private asignacionService: AsignacionService
  ) {}

  ngOnInit(): void {
    this.cargarDatos();
  }

  cargarDatos(): void {

    this.cargando.set(true);

    this.cargarPeliculas();
    this.cargarSalas();
    this.cargarAsignaciones();
  }

  // Cargar películas
  cargarPeliculas(): void {

    this.peliculaService
      .obtenerPeliculas()
      .subscribe({

        next: (respuesta) => {

          this.peliculas.set(respuesta);

          this.peliculasCargadas = true;

          this.verificarCarga();
        },

        error: (error) => {

          console.error(
            'Error al cargar películas:',
            error
          );

          this.error.set(
            'No se pudieron cargar las películas'
          );

          this.peliculasCargadas = true;

          this.verificarCarga();
        }

      });
  }

  // Cargar salas
  cargarSalas(): void {

    this.salaService
      .obtenerSalas()
      .subscribe({

        next: (respuesta) => {

          this.salas.set(respuesta);

          this.salasCargadas = true;

          this.verificarCarga();
        },

        error: (error) => {

          console.error(
            'Error al cargar salas:',
            error
          );

          this.error.set(
            'No se pudieron cargar las salas'
          );

          this.salasCargadas = true;

          this.verificarCarga();
        }

      });
  }

  // Cargar asignaciones
  cargarAsignaciones(): void {

    this.asignacionService
      .obtenerAsignaciones()
      .subscribe({

        next: (respuesta) => {

          this.asignaciones.set(respuesta);

          this.asignacionesCargadas = true;

          this.verificarCarga();

          console.log(
            'Asignaciones:',
            respuesta
          );
        },

        error: (error) => {

          console.error(
            'Error al cargar asignaciones:',
            error
          );

          this.error.set(
            'No se pudieron cargar las asignaciones'
          );

          this.asignacionesCargadas = true;

          this.verificarCarga();
        }

      });
  }

  // Verificar que terminaron las consultas
  verificarCarga(): void {

    if (
      this.peliculasCargadas &&
      this.salasCargadas &&
      this.asignacionesCargadas
    ) {

      this.cargando.set(false);
    }
  }

  // Guardar asignación
  guardar(): void {

    this.mensaje.set('');
    this.error.set('');

    if (
      this.idPelicula == null ||
      this.idSalaCine == null ||
      !this.fechaPublicacion ||
      !this.fechaFin
    ) {

      this.error.set(
        'Debe completar todos los campos'
      );

      return;
    }

    if (
      this.fechaFin < this.fechaPublicacion
    ) {

      this.error.set(
        'La fecha fin no puede ser menor a la fecha de publicación'
      );

      return;
    }

    const asignacion: Asignacion = {

      idPelicula: this.idPelicula,

      idSalaCine: this.idSalaCine,

      fechaPublicacion:
        this.fechaPublicacion,

      fechaFin:
        this.fechaFin
    };

    this.asignacionService
      .crearAsignacion(asignacion)
      .subscribe({

        next: (respuesta) => {

          this.mensaje.set(respuesta);

          this.limpiarFormulario();

          // Volvemos a consultar para actualizar la tabla
          this.cargarAsignaciones();
        },

        error: (error) => {

          console.error(
            'Error al crear asignación:',
            error
          );

          if (
            typeof error.error === 'string'
          ) {

            this.error.set(
              error.error
            );

          } else {

            this.error.set(
              'No se pudo realizar la asignación'
            );
          }
        }

      });
  }

  // Limpiar formulario
  limpiarFormulario(): void {

    this.idPelicula = null;

    this.idSalaCine = null;

    this.fechaPublicacion = '';

    this.fechaFin = '';
  }

}

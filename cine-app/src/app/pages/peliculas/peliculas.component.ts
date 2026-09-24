import { Component, OnInit, signal } from '@angular/core';
import { Pelicula } from '../../models/pelicula';
import { PeliculaService } from '../../services/pelicula.service.ts.service';

@Component({
  selector: 'app-peliculas',
  standalone: false,
  styleUrl: './peliculas.component.scss',
  templateUrl: './peliculas.component.html',
})
export class PeliculasComponent implements OnInit {

  peliculas = signal<Pelicula[]>([]);
  cargando = signal<boolean>(false);
  mensaje = signal<string>('');
  error = signal<string>('');

  nombre: string = '';
  duracion: number | null = null;

  idEditar: number | null = null;

  constructor(
    private peliculaService: PeliculaService
  ) {}

  ngOnInit(): void {
    this.obtenerPeliculas();
  }

  obtenerPeliculas(): void {
    this.cargando.set(true);
    this.error.set('');

    this.peliculaService.obtenerPeliculas()
      .subscribe({
        next: (respuesta) => {
          this.peliculas.set(respuesta);
          this.cargando.set(false);
        },

        error: (error) => {
          console.error(error);
          this.error.set('No se pudieron cargar las películas');
          this.cargando.set(false);
        }
      });
  }

  guardar(): void {
    this.mensaje.set('');
    this.error.set('');

    if (!this.nombre || !this.duracion) {
      this.error.set('Debe ingresar nombre y duración');
      return;
    }

    if (this.duracion <= 0) {
      this.error.set('La duración debe ser mayor a 0');
      return;
    }

    const pelicula: Pelicula = {
      idPelicula: this.idEditar ?? 0,
      nombre: this.nombre,
      duracion: this.duracion,
      estado: true
    };

    if (this.idEditar == null) {
      this.crearPelicula(pelicula);
    } else {
      this.actualizarPelicula(pelicula);
    }
  }

  crearPelicula(pelicula: Pelicula): void {
    this.peliculaService.crearPelicula(pelicula)
      .subscribe({
        next: () => {
          this.mensaje.set('Película creada correctamente');

          this.limpiarFormulario();

          this.obtenerPeliculas();
        },

        error: (error) => {
          console.error(error);
          this.error.set('No se pudo crear la película');
        }
      });
  }

  editar(pelicula: Pelicula): void {
    this.idEditar = pelicula.idPelicula;
    this.nombre = pelicula.nombre;
    this.duracion = pelicula.duracion;

    this.mensaje.set('');
    this.error.set('');
  }

  actualizarPelicula(pelicula: Pelicula): void {
    if (this.idEditar == null) {
      return;
    }

    this.peliculaService
      .actualizarPelicula(this.idEditar, pelicula)
      .subscribe({
        next: () => {
          this.mensaje.set('Película actualizada correctamente');

          this.limpiarFormulario();

          this.obtenerPeliculas();
        },

        error: (error) => {
          console.error(error);
          this.error.set('No se pudo actualizar la película');
        }
      });
  }

  eliminar(id: number): void {
    const confirmar = confirm(
      '¿Está seguro de eliminar esta película?'
    );

    if (!confirmar) {
      return;
    }

    this.mensaje.set('');
    this.error.set('');

    this.peliculaService.eliminarPelicula(id)
      .subscribe({
        next: () => {
          this.mensaje.set(
            'Película eliminada correctamente'
          );

          this.obtenerPeliculas();
        },

        error: (error) => {
          console.error(error);
          this.error.set(
            'No se pudo eliminar la película'
          );
        }
      });
  }

  cancelarEdicion(): void {
    this.limpiarFormulario();
  }

  limpiarFormulario(): void {
    this.idEditar = null;
    this.nombre = '';
    this.duracion = null;
  }
}

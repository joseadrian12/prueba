import { Component, OnInit, signal } from '@angular/core';
import { Sala } from '../../models/sala';
import { SalaService } from '../../services/sala.service.ts.service';

@Component({
  selector: 'app-salas',
  standalone: false,
  styleUrl: './salas.component.scss',
  templateUrl: './salas.component.html',
})
export class SalasComponent implements OnInit {

  salas = signal<Sala[]>([]);
  cargando = signal<boolean>(false);

  mensaje = signal<string>('');
  error = signal<string>('');

  nombre: string = '';

  idEditar: number | null = null;

  constructor(
    private salaService: SalaService
  ) {}

  ngOnInit(): void {
    this.obtenerSalas();
  }

  obtenerSalas(): void {

    this.cargando.set(true);
    this.error.set('');

    this.salaService.obtenerSalas()
      .subscribe({
        next: (respuesta) => {

          this.salas.set(respuesta);

          this.cargando.set(false);
        },

        error: (error) => {

          console.error(error);

          this.error.set(
            'No se pudieron cargar las salas'
          );

          this.cargando.set(false);
        }
      });
  }

  guardar(): void {

    this.mensaje.set('');
    this.error.set('');

    if (!this.nombre.trim()) {

      this.error.set(
        'Debe ingresar el nombre de la sala'
      );

      return;
    }

    const sala: Sala = {
      idSala: this.idEditar ?? 0,
      nombre: this.nombre,
      estado: true
    };

    if (this.idEditar == null) {

      this.crearSala(sala);

    } else {

      this.actualizarSala(sala);

    }
  }

  crearSala(sala: Sala): void {

    this.salaService.crearSala(sala)
      .subscribe({
        next: () => {

          this.mensaje.set(
            'Sala creada correctamente'
          );

          this.limpiarFormulario();

          this.obtenerSalas();
        },

        error: (error) => {

          console.error(error);

          this.error.set(
            'No se pudo crear la sala'
          );
        }
      });
  }

  editar(sala: Sala): void {

    this.idEditar = sala.idSala;

    this.nombre = sala.nombre;

    this.mensaje.set('');
    this.error.set('');
  }

  actualizarSala(sala: Sala): void {

    if (this.idEditar == null) {
      return;
    }

    this.salaService
      .actualizarSala(
        this.idEditar,
        sala
      )
      .subscribe({
        next: () => {

          this.mensaje.set(
            'Sala actualizada correctamente'
          );

          this.limpiarFormulario();

          this.obtenerSalas();
        },

        error: (error) => {

          console.error(error);

          this.error.set(
            'No se pudo actualizar la sala'
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

    
  }
  eliminar(id: number): void {

  const confirmar = confirm(
    '¿Está seguro de eliminar esta sala?'
  );

  if (!confirmar) {
    return;
  }

  this.mensaje.set('');
  this.error.set('');

  this.salaService
    .eliminarSala(id)
    .subscribe({

      next: (respuesta) => {

        this.mensaje.set(respuesta);

        this.obtenerSalas();
      },

      error: (error) => {

        console.error(error);

        this.error.set(
          'No se pudo eliminar la sala'
        );
      }

    });
}
}

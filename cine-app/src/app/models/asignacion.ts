export interface Asignacion {

  idPelicula: number;

  idSalaCine: number;

  fechaPublicacion: string;

  fechaFin: string;
}


export interface AsignacionDetalle {

  idPeliculaSala: number;

  pelicula: string;

  sala: string;

  fechaPublicacion: string;

  fechaFin: string;
}
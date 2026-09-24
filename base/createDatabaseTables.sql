CREATE DATABASE CineDB;
GO

USE CineDB;
GO

CREATE TABLE pelicula
(
    id_pelicula INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    duracion INT NOT NULL,
    estado BIT NOT NULL
);
GO

CREATE TABLE sala_cine
(
    id_sala INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    estado BIT NOT NULL
);
GO


CREATE TABLE pelicula_salacine
(
    id_pelicula_sala INT IDENTITY(1,1) PRIMARY KEY,
    id_sala_cine INT NOT NULL,
    fecha_publicacion DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    id_pelicula INT NOT NULL,

    FOREIGN KEY (id_sala_cine) REFERENCES sala_cine(id_sala),
    FOREIGN KEY (id_pelicula) REFERENCES pelicula(id_pelicula)
);
GO


INSERT INTO pelicula (nombre, duracion, estado)
VALUES
('Avengers', 180, 1),
('Interstellar', 169, 1),
('Batman', 152, 1),
('Inception', 148, 1),
('Titanic', 194, 1),
('Avatar', 162, 1);
GO

SELECT * FROM pelicula

INSERT INTO sala_cine (nombre, estado)
VALUES
('Sala 1', 1),
('Sala 2', 1),
('Sala 3', 1);
GO

SELECT * FROM sala_cine

INSERT INTO pelicula_salacine
(id_sala_cine, fecha_publicacion, fecha_fin, id_pelicula)
VALUES
(1, '2026-09-23', '2026-09-30', 1),
(1, '2026-09-23', '2026-09-30', 2);
GO

INSERT INTO pelicula_salacine
(id_sala_cine, fecha_publicacion, fecha_fin, id_pelicula)
VALUES
(2, '2026-09-23', '2026-09-30', 1),
(2, '2026-09-23', '2026-09-30', 2),
(2, '2026-09-23', '2026-09-30', 3),
(2, '2026-09-23', '2026-09-30', 4);
GO

INSERT INTO pelicula_salacine
(id_sala_cine, fecha_publicacion, fecha_fin, id_pelicula)
VALUES
(3, '2026-09-23', '2026-09-30', 1),
(3, '2026-09-23', '2026-09-30', 2),
(3, '2026-09-23', '2026-09-30', 3),
(3, '2026-09-23', '2026-09-30', 4),
(3, '2026-09-23', '2026-09-30', 5),
(3, '2026-09-23', '2026-09-30', 6);
GO
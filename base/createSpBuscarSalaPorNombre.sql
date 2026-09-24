CREATE OR ALTER PROCEDURE sp_BuscarSalaPorNombre
    @nombre VARCHAR(100)
AS
BEGIN

    DECLARE @idSala INT;
    DECLARE @cantidadPeliculas INT;

    SELECT @idSala = id_sala
    FROM sala_cine
    WHERE nombre = @nombre
    AND estado = 1;


    IF @idSala IS NULL
    BEGIN
        SELECT
            0 AS cantidadPeliculas,
            'Sala no encontrada' AS mensaje;

        RETURN;
    END


    SELECT @cantidadPeliculas = COUNT(*)
    FROM pelicula_salacine ps
    INNER JOIN pelicula p
        ON ps.id_pelicula = p.id_pelicula
    WHERE ps.id_sala_cine = @idSala
    AND p.estado = 1;


    IF @cantidadPeliculas < 3
    BEGIN
        SELECT
            @cantidadPeliculas AS cantidadPeliculas,
            'Sala disponible' AS mensaje;
    END
    ELSE IF @cantidadPeliculas BETWEEN 3 AND 5
    BEGIN
        SELECT
            @cantidadPeliculas AS cantidadPeliculas,
            'Sala con ' + CAST(@cantidadPeliculas AS VARCHAR)
            + ' peliculas asignadas' AS mensaje;
    END
    ELSE
    BEGIN
        SELECT
            @cantidadPeliculas AS cantidadPeliculas,
            'Sala no disponible' AS mensaje;
    END

END;
GO

using CineApi.Data;
using CineApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CineApi.Repository
{
    public class AsignacionRepository
    {
        private readonly CineContext _context;

        public AsignacionRepository(CineContext context)
        {
            _context = context;
        }
        public async Task<Pelicula?> ObtenerPelicula(int idPelicula)
        {
            return await _context.Peliculas
                .FirstOrDefaultAsync(p =>
                    p.IdPelicula == idPelicula &&
                    p.Estado == true);
        }

        public async Task<SalaCine?> ObtenerSala(int idSala)
        {
            return await _context.SalasCine
                .FirstOrDefaultAsync(s =>
                    s.IdSala == idSala &&
                    s.Estado == true);
        }

        public async Task<PeliculaSalaCine> CrearAsignacion(
            PeliculaSalaCine asignacion)
        {
            _context.PeliculasSalasCine.Add(asignacion);

            await _context.SaveChangesAsync();

            return asignacion;
        }
        public async Task<List<AsignacionDetalleDto>> ObtenerAsignaciones()
        {
            var asignaciones = await (
                from ps in _context.PeliculasSalasCine
                join p in _context.Peliculas
                    on ps.IdPelicula equals p.IdPelicula
                join s in _context.SalasCine
                    on ps.IdSalaCine equals s.IdSala
                where p.Estado == true && s.Estado == true
                select new AsignacionDetalleDto
                {
                    IdPeliculaSala = ps.IdPeliculaSala,
                    Pelicula = p.Nombre,
                    Sala = s.Nombre,
                    FechaPublicacion = ps.FechaPublicacion,
                    FechaFin = ps.FechaFin
                }
            ).ToListAsync();

            return asignaciones;
        }
    }

}

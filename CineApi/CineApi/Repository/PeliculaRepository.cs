using CineApi.Data;
using CineApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CineApi.Repository
{
    public class PeliculaRepository
    {
        private readonly CineContext _context;

        public PeliculaRepository(CineContext context)
        {
            _context = context;
        }

        public async Task<List<Pelicula>> ObtenerPeliculas()
        {
            return await _context.Peliculas
                .Where(p => p.Estado == true)
                .ToListAsync();
        }

        public async Task<Pelicula?> ObtenerPeliculaPorId(int id)
        {
            return await _context.Peliculas
                .FirstOrDefaultAsync(p => p.IdPelicula == id && p.Estado == true);
        }

        public async Task<Pelicula> CrearPelicula(Pelicula pelicula)
        {
            pelicula.Estado = true;

            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();

            return pelicula;
        }

        public async Task<Pelicula> ActualizarPelicula(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            await _context.SaveChangesAsync();

            return pelicula;
        }

        public async Task<bool> EliminarPelicula(Pelicula pelicula)
        {
            pelicula.Estado = false;

            _context.Peliculas.Update(pelicula);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Pelicula>> BuscarPorNombre(string nombre)
        {
            return await _context.Peliculas
                .Where(p => p.Nombre.Contains(nombre) && p.Estado == true)
                .ToListAsync();
        }
        public async Task<List<Pelicula>> BuscarPorFecha(DateTime fecha)
        {
            return await _context.Peliculas
                .Join(
                    _context.PeliculasSalasCine,
                    pelicula => pelicula.IdPelicula,
                    relacion => relacion.IdPelicula,
                    (pelicula, relacion) => new
                    {
                        Pelicula = pelicula,
                        Relacion = relacion
                    }
                )
                .Where(x =>
                    x.Relacion.FechaPublicacion.Date == fecha.Date &&
                    x.Pelicula.Estado == true
                )
                .Select(x => x.Pelicula)
                .ToListAsync();
        }

    }
}

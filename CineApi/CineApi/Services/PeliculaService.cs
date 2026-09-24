using CineApi.Models;
using CineApi.Repository;

namespace CineApi.Services
{
    public class PeliculaService
    {
        private readonly PeliculaRepository _repository;

        public PeliculaService(PeliculaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Pelicula>> ObtenerPeliculas()
        {
            return await _repository.ObtenerPeliculas();
        }

        public async Task<Pelicula?> ObtenerPeliculaPorId(int id)
        {
            return await _repository.ObtenerPeliculaPorId(id);
        }

        public async Task<Pelicula> CrearPelicula(Pelicula pelicula)
        {
            return await _repository.CrearPelicula(pelicula);
        }

        public async Task<Pelicula?> ActualizarPelicula(int id, Pelicula pelicula)
        {
            var peliculaExiste = await _repository.ObtenerPeliculaPorId(id);

            if (peliculaExiste == null)
            {
                return null;
            }

            peliculaExiste.Nombre = pelicula.Nombre;
            peliculaExiste.Duracion = pelicula.Duracion;

            return await _repository.ActualizarPelicula(peliculaExiste);
        }

        public async Task<bool> EliminarPelicula(int id)
        {
            var pelicula = await _repository.ObtenerPeliculaPorId(id);

            if (pelicula == null)
            {
                return false;
            }

            return await _repository.EliminarPelicula(pelicula);
        }

        public async Task<List<Pelicula>> BuscarPorNombre(string nombre)
        {
            return await _repository.BuscarPorNombre(nombre);
        }
        public async Task<List<Pelicula>> BuscarPorFecha(DateTime fecha)
        {
            return await _repository.BuscarPorFecha(fecha);
        }
    }
}

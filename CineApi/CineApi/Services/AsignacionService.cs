using CineApi.Models;
using CineApi.Repository;

namespace CineApi.Services
{
    public class AsignacionService
    {
        private readonly AsignacionRepository _repository;

        public AsignacionService(AsignacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> CrearAsignacion(
            AsignacionPeliculaDto datos)
        {
            var pelicula =
                await _repository.ObtenerPelicula(datos.IdPelicula);

            if (pelicula == null)
            {
                return "PELICULA_NO_EXISTE";
            }


            var sala =
                await _repository.ObtenerSala(datos.IdSalaCine);

            if (sala == null)
            {
                return "SALA_NO_EXISTE";
            }


            if (datos.FechaFin < datos.FechaPublicacion)
            {
                return "FECHA_INVALIDA";
            }


            var asignacion = new PeliculaSalaCine
            {
                IdPelicula = datos.IdPelicula,
                IdSalaCine = datos.IdSalaCine,
                FechaPublicacion = datos.FechaPublicacion,
                FechaFin = datos.FechaFin
            };


            await _repository.CrearAsignacion(asignacion);

            return "OK";
        }
        public async Task<List<AsignacionDetalleDto>> ObtenerAsignaciones()
        {
            return await _repository.ObtenerAsignaciones();
        }
    }
}

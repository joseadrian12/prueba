using CineApi.Models;
using CineApi.Repository;

namespace CineApi.Services
{
    public class SalaService
    {
        private readonly SalaRepository _repository;

        public SalaService(SalaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<SalaCine>> ObtenerSalas()
        {
            return await _repository.ObtenerSalas();
        }
        public async Task<SalaCine?> ObtenerSalaPorId(int id)
        {
            return await _repository.ObtenerSalaPorId(id);
        }

        public async Task<SalaCine> CrearSala(SalaCine sala)
        {
            return await _repository.CrearSala(sala);
        }

        public async Task<SalaCine?> ActualizarSala(
            int id,
            SalaCine sala)
        {
            var salaExiste =
                await _repository.ObtenerSalaPorId(id);

            if (salaExiste == null)
            {
                return null;
            }

            salaExiste.Nombre = sala.Nombre;

            return await _repository
                .ActualizarSala(salaExiste);
        }

        public async Task<bool> EliminarSala(int id)
        {
            var sala =
                await _repository.ObtenerSalaPorId(id);

            if (sala == null)
            {
                return false;
            }

            return await _repository
                .EliminarSala(sala);
        }

        public async Task<SalaDisponibilidad?>
            BuscarSalaPorNombre(string nombre)
        {
            return await _repository
                .BuscarSalaPorNombre(nombre);
        }
    }
}

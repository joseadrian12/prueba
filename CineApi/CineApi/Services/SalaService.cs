using CineApi.Models;
using CineApi.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CineApi.Services
{
    public class SalaService
    {
        private readonly SalaRepository _salaRepo;

        public SalaService(SalaRepository SalaRepo)
        {
            _salaRepo = SalaRepo;
        }

        public async Task<SalaDisponibilidad?> BuscarSalaPorNombre(string nombre)
        {
            return await _salaRepo.BuscarSalaPorNombre(nombre);
        }
        public async Task<List<SalaCine>> ObtenerSalas()
        {
            return await _salaRepo.ObtenerSalas();

        }
    }
}

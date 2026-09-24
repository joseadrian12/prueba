using CineApi.Models;
using CineApi.Repository;

namespace CineApi.Services
{
    public class DashboardService
    {
        private readonly DashboardRepository _repository;

        public DashboardService(DashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardDto> ObtenerDatos()
        {
            return await _repository.ObtenerDatos();
        }
    }
}

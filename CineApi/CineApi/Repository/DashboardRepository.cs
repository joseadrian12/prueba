using CineApi.Data;
using CineApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CineApi.Repository
{
    public class DashboardRepository
    {
        private readonly CineContext _context;
        private readonly SalaRepository _salaRepository;

        public DashboardRepository(
            CineContext context,
            SalaRepository salaRepository)
        {
            _context = context;
            _salaRepository = salaRepository;
        }

        public async Task<DashboardDto> ObtenerDatos()
        {
            var totalSalas = await _context.SalasCine
                .CountAsync(s => s.Estado == true);

            var totalPeliculas = await _context.Peliculas
                .CountAsync(p => p.Estado == true);


            var disponibilidadSalas =
                await _salaRepository
                    .ObtenerDisponibilidadSalas();


            var salasDisponibles =
                disponibilidadSalas.Count(
                    s => s.Mensaje == "Sala disponible"
                );


            return new DashboardDto
            {
                TotalSalas = totalSalas,
                SalasDisponibles = salasDisponibles,
                TotalPeliculas = totalPeliculas
            };
        }
    }
}
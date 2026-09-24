using CineApi.Data;
using CineApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CineApi.Repository
{
    public class DashboardRepository
    {
        private readonly CineContext _context;

        public DashboardRepository(CineContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> ObtenerDatos()
        {
            var totalSalas = await _context.SalasCine
                .CountAsync(s => s.Estado == true);

            var totalPeliculas = await _context.Peliculas
                .CountAsync(p => p.Estado == true);

            var salas = await _context.SalasCine
                .Where(s => s.Estado == true)
                .ToListAsync();

            int salasDisponibles = 0;

            foreach (var sala in salas)
            {
                var cantidadPeliculas = await _context.PeliculasSalasCine
                    .CountAsync(p => p.IdSalaCine == sala.IdSala);

                if (cantidadPeliculas < 3)
                {
                    salasDisponibles++;
                }
            }

            return new DashboardDto
            {
                TotalSalas = totalSalas,
                SalasDisponibles = salasDisponibles,
                TotalPeliculas = totalPeliculas
            };
        }
    }
}

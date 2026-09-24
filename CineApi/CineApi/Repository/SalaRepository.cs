using CineApi.Data;
using CineApi.Models;
using Microsoft.EntityFrameworkCore;


namespace CineApi.Repository
{
    public class SalaRepository
    {
        private readonly CineContext _context;

        public SalaRepository(CineContext context)
        {
            _context = context;
        }

        public async Task<SalaDisponibilidad?> BuscarSalaPorNombre(string nombre)
        {
            var resultado = await _context.SalaDisponibilidad
                .FromSqlInterpolated(
                    $"EXEC sp_BuscarSalaPorNombre @nombre = {nombre}"
                )
                .ToListAsync();

            return resultado.FirstOrDefault();

        }
        public async Task<List<SalaCine>> ObtenerSalas()
        {
            return await _context.SalasCine
                .Where(s => s.Estado == true)
                .ToListAsync();
        }
    }
}

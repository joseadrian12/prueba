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

        public async Task<List<SalaCine>> ObtenerSalas()
        {
            return await _context.SalasCine
                .Where(s => s.Estado == true)
                .ToListAsync();
        }

        public async Task<SalaCine?> ObtenerSalaPorId(int id)
        {
            return await _context.SalasCine
                .FirstOrDefaultAsync(s =>
                    s.IdSala == id &&
                    s.Estado == true);
        }

        public async Task<SalaCine> CrearSala(SalaCine sala)
        {
            sala.Estado = true;

            _context.SalasCine.Add(sala);

            await _context.SaveChangesAsync();

            return sala;
        }

        public async Task<SalaCine> ActualizarSala(SalaCine sala)
        {
            _context.SalasCine.Update(sala);

            await _context.SaveChangesAsync();

            return sala;
        }


        public async Task<bool> EliminarSala(SalaCine sala)
        {
            sala.Estado = false;

            _context.SalasCine.Update(sala);

            await _context.SaveChangesAsync();

            return true;
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


        public async Task<List<SalaDisponibilidad>> ObtenerDisponibilidadSalas()
        {
            return await _context.SalaDisponibilidad
                .FromSqlRaw(
                    "EXEC sp_BuscarSalaPorNombre @nombre = NULL"
                )
                .ToListAsync();
        }
    }
}
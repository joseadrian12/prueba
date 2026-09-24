using CineApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CineApi.Data
{
    public class CineContext : DbContext
    {
        public CineContext(DbContextOptions<CineContext> options)
            : base(options)
        {
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<SalaCine> SalasCine { get; set; }
        public DbSet<PeliculaSalaCine> PeliculasSalasCine { get; set; }

        public DbSet<SalaDisponibilidad> SalaDisponibilidad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalaDisponibilidad>().HasNoKey();
        }
    }
}

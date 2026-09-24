using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineApi.Models
{
    [Table("pelicula_salacine")]
    public class PeliculaSalaCine
    {
        [Key]
        [Column("id_pelicula_sala")]
        public int IdPeliculaSala { get; set; }

        [Column("id_sala_cine")]
        public int IdSalaCine { get; set; }

        [Column("fecha_publicacion")]
        public DateTime FechaPublicacion { get; set; }

        [Column("fecha_fin")]
        public DateTime FechaFin { get; set; }

        [Column("id_pelicula")]
        public int IdPelicula { get; set; }
    }
}

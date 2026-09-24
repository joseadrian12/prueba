using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineApi.Models
{

    [Table("pelicula")]
    public class Pelicula
    {
        [Key]
        [Column("id_pelicula")]
        public int IdPelicula { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("duracion")]
        public int Duracion { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }
    }

}

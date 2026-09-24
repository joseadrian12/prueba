using System.ComponentModel.DataAnnotations.Schema;

namespace CineApi.Models
{
    public class SalaDisponibilidad
    {
        [Column("cantidadPeliculas")]
        public int CantidadPeliculas { get; set; }

        [Column("mensaje")]
        public string Mensaje { get; set; } = string.Empty;
    }
}

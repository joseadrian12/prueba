using System.ComponentModel.DataAnnotations.Schema;

namespace CineApi.Models
{
    public class SalaDisponibilidad
    {
        [Column("idSala")]
        public int IdSala { get; set; }

        [Column("nombreSala")]
        public string NombreSala { get; set; } = string.Empty;

        [Column("cantidadPeliculas")]
        public int CantidadPeliculas { get; set; }

        [Column("mensaje")]
        public string Mensaje { get; set; } = string.Empty;
    }
}

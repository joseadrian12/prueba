

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineApi.Models
{
    [Table("sala_cine")]
    public class SalaCine
    {
        [Key]
        [Column("id_sala")]
        public int IdSala { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("estado")]
        public bool Estado { get; set; }
    }
}

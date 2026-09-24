namespace CineApi.Models
{
    public class AsignacionDetalleDto
    {
        public int IdPeliculaSala { get; set; }

        public string Pelicula { get; set; } = string.Empty;

        public string Sala { get; set; } = string.Empty;

        public DateTime FechaPublicacion { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
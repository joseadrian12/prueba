using CineApi.Models;
using CineApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly PeliculaService _service;

        public PeliculaController(PeliculaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPeliculas()
        {
            var peliculas = await _service.ObtenerPeliculas();

            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPeliculaPorId(int id)
        {
            var pelicula = await _service.ObtenerPeliculaPorId(id);

            if (pelicula == null)
            {
                return NotFound("Película no encontrada");
            }

            return Ok(pelicula);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPelicula(Pelicula pelicula)
        {
            var nuevaPelicula = await _service.CrearPelicula(pelicula);

            return Ok(nuevaPelicula);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPelicula(
            int id,
            Pelicula pelicula)
        {
            var peliculaActualizada =
                await _service.ActualizarPelicula(id, pelicula);

            if (peliculaActualizada == null)
            {
                return NotFound("Película no encontrada");
            }

            return Ok(peliculaActualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPelicula(int id)
        {
            var resultado = await _service.EliminarPelicula(id);

            if (!resultado)
            {
                return NotFound("Película no encontrada");
            }

            return Ok("Película eliminada correctamente");
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return BadRequest("Debe ingresar un nombre");
            }

            var peliculas = await _service.BuscarPorNombre(nombre);

            if (peliculas.Count == 0)
            {
                return NotFound("No se encontraron películas");
            }

            return Ok(peliculas);
        }

        [HttpGet("fecha")]
        public async Task<IActionResult> BuscarPorFecha(string fecha)
        {
            DateTime fechaConvertida;

            if (!DateTime.TryParse(fecha, out fechaConvertida))
            {
                return BadRequest("La fecha ingresada no es válida");
            }

            var peliculas = await _service.BuscarPorFecha(fechaConvertida);

            if (peliculas.Count == 0)
            {
                return NotFound("No se encontraron películas para la fecha indicada");
            }

            return Ok(peliculas);
        }
    }

}


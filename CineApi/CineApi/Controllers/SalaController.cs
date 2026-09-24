using CineApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly SalaService _serviSala;

        public SalaController(SalaService serviSala)
        {
            _serviSala = serviSala;
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarSalaPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return BadRequest("Debe ingresar el nombre de la sala");
            }

            var resultado = await _serviSala.BuscarSalaPorNombre(nombre);

            if (resultado == null)
            {
                return NotFound("Sala no encontrada");
            }

            return Ok(resultado);
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerSalas()
        {
            var salas = await _serviSala.ObtenerSalas();

            return Ok(salas);
        }
    }
}

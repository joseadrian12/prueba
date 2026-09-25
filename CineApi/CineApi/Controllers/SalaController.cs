using CineApi.Models;
using CineApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SalaController : ControllerBase
    {
        private readonly SalaService _service;

        public SalaController(SalaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerSalas()
        {
            var salas =
                await _service.ObtenerSalas();

            return Ok(salas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerSalaPorId(int id)
        {
            var sala =
                await _service.ObtenerSalaPorId(id);

            if (sala == null)
            {
                return NotFound(
                    "Sala no encontrada"
                );
            }

            return Ok(sala);
        }


        [HttpPost]
        public async Task<IActionResult> CrearSala(
            SalaCine sala)
        {
            if (string.IsNullOrEmpty(sala.Nombre))
            {
                return BadRequest(
                    "Debe ingresar el nombre de la sala"
                );
            }

            var nuevaSala =
                await _service.CrearSala(sala);

            return Ok(nuevaSala);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarSala(
            int id,
            SalaCine sala)
        {
            if (string.IsNullOrEmpty(sala.Nombre))
            {
                return BadRequest(
                    "Debe ingresar el nombre de la sala"
                );
            }

            var salaActualizada =
                await _service.ActualizarSala(
                    id,
                    sala
                );

            if (salaActualizada == null)
            {
                return NotFound(
                    "Sala no encontrada"
                );
            }

            return Ok(salaActualizada);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSala(int id)
        {
            var resultado =
                await _service.EliminarSala(id);

            if (!resultado)
            {
                return NotFound(
                    "Sala no encontrada"
                );
            }

            return Ok(
                "Sala eliminada correctamente"
            );
        }


        [HttpGet("buscar")]
        public async Task<IActionResult>
            BuscarSalaPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return BadRequest(
                    "Debe ingresar el nombre de la sala"
                );
            }

            var resultado =
                await _service
                    .BuscarSalaPorNombre(nombre);

            if (
                resultado == null ||
                resultado.Mensaje == "Sala no encontrada"
            )
            {
                return NotFound(
                    "Sala no encontrada"
                );
            }

            return Ok(resultado);
        }
    }
}
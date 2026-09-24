using CineApi.Models;
using CineApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionController : ControllerBase
    {
        private readonly AsignacionService _service;
        public AsignacionController(AsignacionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearAsignacion(
            AsignacionPeliculaDto datos)
        {
            var resultado =
                await _service.CrearAsignacion(datos);


            if (resultado == "PELICULA_NO_EXISTE")
            {
                return BadRequest("La película no existe");
            }

            if (resultado == "SALA_NO_EXISTE")
            {
                return BadRequest("La sala no existe");
            }

            if (resultado == "FECHA_INVALIDA")
            {
                return BadRequest(
                    "La fecha fin no puede ser menor a la fecha de publicación");
            }


            return Ok("Película asignada correctamente");
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerAsignaciones()
        {
            var asignaciones = await _service.ObtenerAsignaciones();

            return Ok(asignaciones);
        }
    }
}

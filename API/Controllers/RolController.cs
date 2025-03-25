using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Application.Interfaces.Services;
using Project_API.Domain.Entities;

namespace Project_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [Authorize]
        [HttpGet("ObtenerRoles")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Rol> rols = await _rolService.GetAllAsync();
            return Ok(rols);
        }

        [Authorize]
        [HttpGet("ObtenerRol/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Rol rol = await _rolService.GetByIdAsync(id);
            if (rol == null) return NotFound($"Rol con ID {id} no encontrado.");
            return Ok(rol);
        }

        [Authorize]
        [HttpPost("CrearRol")]
        public async Task<IActionResult> AddAsync([FromBody] Rol rol)
        {
            Rol nuevoRol = await _rolService.AddAsync(rol);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevoRol.Id }, nuevoRol);
        }

        [Authorize]
        [HttpPut("ActualizarRol/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Rol rol)
        {
            if (id != rol.Id) return BadRequest("El ID del rol no coincide.");

            bool actualizado = await _rolService.UpdateAsync(rol);
            if (!actualizado) return BadRequest("No se pudo actualizar el rol.");

            return NoContent();
        }

        [Authorize]
        [HttpDelete("EliminarRol/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool eliminado = await _rolService.DeleteAsync(id);
            if (!eliminado) return NotFound($"Rol con ID {id} no encontrado.");

            return NoContent();
        }
    }
}

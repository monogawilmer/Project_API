using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_API.Application.Interfaces.Services;
using Project_API.Domain.DTOs;
using Project_API.Domain.Entities;

namespace Project_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize]
        [HttpGet("ObtenerUsuarios")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<UsuarioDTO> usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }

        [Authorize]
        [HttpGet("ObtenerUsuario/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            UsuarioDTO usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null) return NotFound($"Usuario con ID {id} no encontrado.");
            return Ok(usuario);
        }

        [Authorize]
        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> AddAsync([FromBody] Usuario usuario)
        {
            UsuarioDTO nuevoUsuario = await _usuarioService.AddAsync(usuario);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevoUsuario.Id }, nuevoUsuario);
        }

        [Authorize]
        [HttpPut("ActualizarUsuario/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest("El ID del usuario no coincide.");

            bool actualizado = await _usuarioService.UpdateAsync(usuario);
            if (!actualizado) return BadRequest("No se pudo actualizar el usuario.");

            return NoContent();
        }

        [Authorize]
        [HttpDelete("EliminarUsuario/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool eliminado = await _usuarioService.DeleteAsync(id);
            if (!eliminado) return NotFound($"Usuario con ID {id} no encontrado.");

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Application.Interfaces.Services;
using Project_API.Domain.DTOs;
using Project_API.Domain.Entities;

namespace Project_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoService _tipoDocumentoService;

        public TipoDocumentoController(ITipoDocumentoService tipoDocumentoService)
        {
            _tipoDocumentoService = tipoDocumentoService;
        }

        [Authorize]
        [HttpGet("ObtenerTipoDocumentos")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<TipoDocumentoDTO> tipoDocumento = await _tipoDocumentoService.GetAllAsync();
            return Ok(tipoDocumento);
        }

        [Authorize]
        [HttpGet("ObtenerTipoDocumento/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            TipoDocumentoDTO tipoDocumento = await _tipoDocumentoService.GetByIdAsync(id);
            if (tipoDocumento == null) return NotFound($"Tipo de documento con ID {id} no encontrado.");
            return Ok(tipoDocumento);
        }

        [Authorize]
        [HttpPost("CrearTipoDocumento")]
        public async Task<IActionResult> AddAsync([FromBody] TipoDocumento tipoDocumento)
        {
            TipoDocumentoDTO nuevoTipoDocumento = await _tipoDocumentoService.AddAsync(tipoDocumento);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevoTipoDocumento.Id }, nuevoTipoDocumento);
        }

        [Authorize]
        [HttpPut("ActualizarTipoDocumento/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.Id) return BadRequest("El ID del tipo de documento no coincide.");

            bool actualizado = await _tipoDocumentoService.UpdateAsync(tipoDocumento);
            if (!actualizado) return BadRequest("No se pudo actualizar el tipo de documento.");

            return NoContent();
        }

        [Authorize]
        [HttpDelete("EliminarTipoDocumento/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool eliminado = await _tipoDocumentoService.DeleteAsync(id);
            if (!eliminado) return NotFound($"Tipo de documento con ID {id} no encontrado.");

            return NoContent();
        }
    }
}

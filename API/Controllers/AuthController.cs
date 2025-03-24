using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Application.Interfaces.Services;
using Project_API.Domain.DTOs;

namespace Project_API.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var token = await _authService.AuthenticateAsync(request.Email, request.Password);

            if (token == null)
                return Unauthorized(new { message = "Credenciales incorrectas." });

            return Ok(new { token });
        }
    }
}

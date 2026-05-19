using Biblioteca.DTOs;
using Biblioteca.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            if (dto.Usuario != "admin" || dto.Senha != "admin123")
                return Unauthorized("Usuário ou senha inválidos.");

            var token = _tokenService.GerarToken(dto.Usuario);

            return Ok(new { token });
        }
    }
}

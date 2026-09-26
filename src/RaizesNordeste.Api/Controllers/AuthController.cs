using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Servicos;

namespace RaizesNordeste.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
    
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
    
    
        [HttpPost("login")]
        public async Task<IActionResult> CriarCliente(
            [FromBody] LoginDTO dto)
        {
            var token = await _authService.Login(dto.Email, dto.Senha);
    
    
            if (token == null)
            {
                return Unauthorized("Email ou senha incorretos. Tente novamente");
            }
    
            return Ok(new {token});
    
    
        }
    
    
    }
    
}

using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Servicos;
using RaizesNordeste.Api.Helpers;

namespace RaizesNordeste.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
    
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginRespostaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(
            [FromBody] LoginDTO dto)
        {
            var token = await _authService.Login(dto.Email, dto.Senha);
    
    
            if (token == null)
            {
                return Unauthorized(ErroRespostaHelper.NaoAutenticado("Email ou senha incorretos. Tente novamente"));
            }

            return Ok(new LoginRespostaDTO
            {
                Token = token
            }); 
    
    
        }
    
    
    }
    
}

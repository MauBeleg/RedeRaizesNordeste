using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Services;

namespace RaizesNordeste.Api.Controllers
{
    [ApiController]
    [Route("api/auditorias")]
    [Produces("application/json")]
    [Authorize(Roles = "ADMIN")]
    public class AuditoriasController : ControllerBase
    {
        private readonly AuditoriaService _auditoriaService;

        public AuditoriasController(AuditoriaService auditoriaService)
        {
            _auditoriaService = auditoriaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuditoriaRespostaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarAuditorias([FromQuery] long? usuarioId, [FromQuery] string? acao, [FromQuery] string? entidade, [FromQuery] long? registroId)
        {
            var auditorias = await _auditoriaService.ListarAuditorias(usuarioId, acao, entidade, registroId );

            var resposta = auditorias.Select(a => new AuditoriaRespostaDTO
            {
                Id = a.Id,
                UsuarioId = a.UsuarioId,
                Usuario = a.Usuario.Nome,
                Acao = a.Acao,
                Entidade = a.Entidade,
                RegistroId = a.RegistroId,
                Detalhes = a.Detalhes,
                DataCriacao = a.DataCriacao
            });

            return Ok(resposta);
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Api.Helpers;
using RaizesNordeste.Application.Services;

namespace RaizesNordeste.Api.Controllers
{
    [ApiController]
    [Route("api/consentimentos")]
    [Produces("application/json")]
    [Authorize]
    public class ConsentimentosController : ControllerBase
    {
        private readonly ConsentimentoService _consentimentoService;

        public ConsentimentosController(ConsentimentoService consentimentoService)
        {
            _consentimentoService = consentimentoService;
        }


        [Authorize(Roles = "CLIENTE")]
        [HttpPost]
        [ProducesResponseType(typeof(ConsentimentoRespostaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Registrar(ConsentimentoRequestDTO dto)
        {
            var usuarioIdClaim = User.FindFirst("UsuarioId")?.Value;

            if (!long.TryParse(usuarioIdClaim, out var usuarioAutenticadoId))
            {
                return Unauthorized(ErroRespostaHelper.NaoAutenticado("Não foi possível identificar o usuário autenticado"));
            }

            try
            {
                var consentimento = await _consentimentoService.RegistrarConsentimento(usuarioAutenticadoId,dto.TipoConsentimento, dto.Aceito);

                var resposta = new ConsentimentoRespostaDTO
                {
                    Id = consentimento.Id,
                    TipoConsentimento = consentimento.TipoConsentimento,
                    Aceito = consentimento.Aceito,
                    DataCriacao = consentimento.DataCriacao
                };

                return StatusCode(StatusCodes.Status201Created, resposta);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ErroRespostaHelper.RequisicaoInvalida(ex.Message));
            }
        }


        [Authorize(Roles = "CLIENTE")]
        [HttpGet("meus")]
        [ProducesResponseType(typeof(IEnumerable<ConsentimentoRespostaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarMeus()
        {
            var usuarioIdClaim = User.FindFirst("UsuarioId")?.Value;

            if (!long.TryParse(usuarioIdClaim, out var usuarioAutenticadoId))
            {
                return Unauthorized(ErroRespostaHelper.NaoAutenticado("Não foi possível identificar o usuário autenticado"));
            }

            var consentimentos = await _consentimentoService.ListarPorUsuario(usuarioAutenticadoId);

            var resposta = consentimentos.Select(consentimento => new ConsentimentoRespostaDTO
                {
                    Id = consentimento.Id,
                    TipoConsentimento = consentimento.TipoConsentimento,
                    Aceito = consentimento.Aceito,
                    DataCriacao = consentimento.DataCriacao
                }).ToList();

            return Ok(resposta);
        }



        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ConsentimentoAdminRespostaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarTodos([FromQuery] long? usuarioId)
        {
            var consentimentos = await _consentimentoService.ListarTodos(usuarioId);

            var resposta = consentimentos.Select(consentimento => new ConsentimentoAdminRespostaDTO
                    {
                        Id = consentimento.Id,
                        UsuarioId = consentimento.UsuarioId,
                        Usuario = consentimento.Usuario.Nome,
                        TipoConsentimento =
                            consentimento.TipoConsentimento,
                        Aceito = consentimento.Aceito,
                        DataCriacao = consentimento.DataCriacao
                    }).ToList();

            return Ok(resposta);
        }
    }
}
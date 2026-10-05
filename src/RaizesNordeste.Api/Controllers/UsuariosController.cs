using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Servicos;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using RaizesNordeste.Api.Helpers;

namespace RaizesNordeste.Api.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        //Criar cliente
        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] CriarUsuarioDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Cpf))
            {
                return BadRequest(ErroRespostaHelper.RequisicaoInvalida("O CPF deve ser informado."));
            }

            if (!dto.DataNascimento.HasValue)
            {
                return BadRequest(ErroRespostaHelper.RequisicaoInvalida("A data de nascimento deve ser informada."));
            }

            var cpf = dto.Cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                return BadRequest(ErroRespostaHelper.RequisicaoInvalida("CPF inválido."));
            }

            if (dto.DataNascimento.Value.Date > DateTime.UtcNow.Date)
            {
                return BadRequest(ErroRespostaHelper.RequisicaoInvalida("A data de nascimento não pode ser futura."));
            }

            var result = await _usuarioService.CriarCliente(dto.Nome, dto.Email, dto.Senha, cpf, dto.DataNascimento.Value);

            if (!result.Resultado)
            {
                return Conflict(ErroRespostaHelper.Conflito(result.Mensagem));
            }

            return StatusCode(201, result.Mensagem);
        }



        // Buscar usuarios
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var usuarios = await _usuarioService.BuscarUsuarios();


            var usuariosDTO = usuarios.Select(usuario => new  UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                PerfilId = usuario.PerfilId,
                UnidadeId = usuario.UnidadeId,
                Setor = usuario.Setor,
                Ativo = usuario.Ativo,
                DataCriacao = usuario.DataCriacao
            }).ToList();


            return Ok(usuariosDTO);

        }

        //Buscar usuario peo id
        [Authorize(Roles = "ADMIN")]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> BuscarUsuarioPorId (long id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(id);
             if (usuario == null)
            {
                return NotFound(ErroRespostaHelper.NaoEncontrado("Usuário não encontrado"));
            }

            UsuarioDTO usuarioDTO = new UsuarioDTO()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                PerfilId = usuario.PerfilId,
                UnidadeId = usuario.UnidadeId,
                Setor = usuario.Setor,
                Ativo = usuario.Ativo,
                DataCriacao = usuario.DataCriacao
            };



            return Ok(usuarioDTO);
        }
    }
}
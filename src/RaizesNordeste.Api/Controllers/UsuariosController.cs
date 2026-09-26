using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Servicos;
using System.Net;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost]
        public async Task<IActionResult> CriarCliente(
            [FromBody] CriarUsuarioDTO dto)
        {
            var result = await _usuarioService.CriarCliente(dto.Nome, dto.Email, dto.Senha);


            if (!result){
                return Conflict("Já existe um usuário cadastrado com este e-mail.");
            }

            return StatusCode(201, "Usuário criado com sucesso.");


        }


    }
}
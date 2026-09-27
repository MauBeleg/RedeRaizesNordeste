using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Servicos;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace RaizesNordeste.Api.Controllers
{
    [ApiController]
    [Route("api/unidades")]
    public class UnidadeController : ControllerBase
    {

        private readonly UnidadeService _unidadeService;


        public UnidadeController(UnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }



        //Buscar Unidades - Cliente
        [HttpGet]
        public async Task<IActionResult> BuscarUnidadesAtivasCliente()
        {
            var unidades = await _unidadeService.BuscarUnidadesAtivas();

            var unidadesDto = unidades.Select(un => new UnidadeClienteDTO
            {
                Id = un.Id,
                Nome = un.Nome
            }).ToList();

            return Ok(unidadesDto);
        }


        //Buscar Unidade pelo id - Cliente
        [HttpGet("{id:long}")]
        public async Task<IActionResult> BuscarUnidadePorIdCliente(long id)
        {
            var unidade = await _unidadeService.BuscarUnidadePorId(id);

            if (unidade == null)
            {
                return NotFound("Unidade não encontrada.");
            }


            UnidadeClienteDTO unidadeDTO = new UnidadeClienteDTO
            {
                Id = unidade.Id,
                Nome = unidade.Nome
            };

            return Ok(unidadeDTO);
        }
    }
}

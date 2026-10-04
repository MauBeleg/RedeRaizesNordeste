using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Servicos;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using RaizesNordeste.Api.Helpers;


namespace RaizesNordeste.Api.Controllers
{

    [ApiController]
    [Route("api/unidades/{unidadeId:long}/cardapio")]
    public class CardapioController : ControllerBase
    {
        private readonly CardapioService _cardapioService;


        public CardapioController(CardapioService cardapioService)
        {
            _cardapioService = cardapioService;
        }

        //Buscar cadrapio da unidade
        [HttpGet]
        public async Task<IActionResult> BuscarCardapioUnidade(long unidadeId)
        {
            var cardapio = await _cardapioService.BuscarCardapioporUnidade(unidadeId);

            if (cardapio == null)
            {
                return NotFound(ErroRespostaHelper.NaoEncontrado("Cardápio não encontrado."));
            }

            CardapioDTO cardapioDTO = new CardapioDTO
            {
                Id = cardapio.Id,
                Nome = cardapio.Nome,
                UnidadeId = cardapio.UnidadeId,
                Produtos = cardapio.Itens.Where(i => i.Ativo && i.Produto.Ativo).Select(i => new ProdutoDTO
                {
                    Id = i.Produto.Id,
                    Nome = i.Produto.Nome,
                    Descricao = i.Produto.Descricao,
                    ValorUnitario = i.Produto.ValorUnitario
                }).ToList()
            };

            return Ok(cardapioDTO);
        }


    }
}

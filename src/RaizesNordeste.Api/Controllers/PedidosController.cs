using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Servicos;
using RaizesNordeste.Application.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

[ApiController]
[Route("api/pedidos")]
[Authorize]
public class PedidosController : ControllerBase
{
    private readonly PedidoService _pedidoService;


    public PedidosController (PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }




    [HttpPost]
    public async Task<IActionResult> CriarPedido(CriarPedidoDTO dto)
    {

        if (dto.CanalPedido == null)
        {
            return BadRequest("Canal de Pedido é obrigatório");
        }

        var usuarioIdClaim = User.FindFirst("UsuarioId")?.Value;

        if (!long.TryParse(usuarioIdClaim, out var usuarioAutenticadoId))
        {
            return Unauthorized();
        }

        var itensInput = new List<CriarPedidoItemInput>();

        foreach (var itemDto in dto.Itens)
        {
            var itemInput = new CriarPedidoItemInput
            {
                ProdutoId = itemDto.ProdutoId,
                Quantidade = itemDto.Quantidade
            };

            itensInput.Add(itemInput);
        }

        var pedido = new CriarPedidoInput
        {
            ClienteId = dto.ClienteId,
            UnidadeId = dto.UnidadeId,
            CanalPedido = dto.CanalPedido.Value,
            UsuarioAutenticadoId = usuarioAutenticadoId,
            Itens = itensInput
        };


        var resultado = await _pedidoService.ValidarCriacaoPedido(pedido);

        if (!resultado.Resultado)
        {
            return BadRequest(resultado.Mensagem);
        }

        return Ok(resultado.Mensagem);

    }


}
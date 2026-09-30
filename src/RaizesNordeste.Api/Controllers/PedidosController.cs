using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Models;
using RaizesNordeste.Application.Servicos;
using RaizesNordeste.Domain.Entities;

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


        if (resultado.Objeto is not PedidoCriadoOutput pedidoOutput)
        {
            return StatusCode(500, "Não foi possível obter os dados do pedido criado");
        }

        var pedidoCriadoItensDTO = new List<PedidoItemRespostaDTO>();

        foreach (var pedidoItem in pedidoOutput.Itens)
        {
            var pedidoItemRespostaDTO = new PedidoItemRespostaDTO
            {
                Produto = pedidoItem.Produto,
                Quantidade = pedidoItem.Quantidade,
                ValorUnitario  = pedidoItem.ValorUnitario,
                ValorTotal = pedidoItem.ValorTotal
            };

            pedidoCriadoItensDTO.Add(pedidoItemRespostaDTO);

        }

        var pedidoCriadoDTO = new PedidoCriadoDTO
        {
            Id = pedidoOutput.Id,
            Cliente = pedidoOutput.Cliente,
            Unidade = pedidoOutput.Unidade,
            CanalPedido = pedidoOutput.CanalPedido,
            Subtotal = pedidoOutput.Subtotal,
            Desconto = pedidoOutput.Desconto,
            ValorTotal = pedidoOutput.ValorTotal,
            Status = pedidoOutput.Status,
            DataCriacao = pedidoOutput.DataCriacao,
            Itens = pedidoCriadoItensDTO
        };


        return StatusCode(StatusCodes.Status201Created, pedidoCriadoDTO);

    }


}
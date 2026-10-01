using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Models;
using RaizesNordeste.Application.Servicos;

[ApiController]
[Route("api/pedidos")]
[Authorize]
public class PedidosController : ControllerBase
{
    private readonly PedidoService _pedidoService;
    private readonly PedidoStatusService _pedidoStatusService;
    private readonly PagamentoService _pagamentoService;


    public PedidosController (PedidoService pedidoService, PedidoStatusService pedidoStatusService, PagamentoService pagamentoService)
    {
        _pedidoService = pedidoService;
        _pedidoStatusService = pedidoStatusService;
        _pagamentoService = pagamentoService;
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
    ///


    [HttpPatch("{id}/status")]
    public async Task<IActionResult> AlterarStatus(long id, AlterarStatusPedidoDTO dto)
    {
        var resultado = await _pedidoStatusService.AlterarStatus(id, dto.Status);

        if (!resultado)
        {
            return BadRequest("Não foi possível alterar o status do pedido");
        }

        return Ok("Status do pedido alterado com sucesso");

    }



    [Authorize(Roles = "ADMIN,FUNCIONARIO,CLIENTE")]
    [HttpPost("{id}/pagamentos")]
    public async Task<IActionResult> ProcessarPagamento(long id, ProcessarPagamentoDTO dto)
    {
        var usuarioIdClaim = User.FindFirst("UsuarioId")?.Value;

        if (!long.TryParse(usuarioIdClaim, out var usuarioAutenticadoId))
        {
            return Unauthorized();
        }

        var aprovar = dto.Aprovar ?? true;

        var resultado = await _pagamentoService.ProcessarPagamento(id, dto.MetodoPagamento, aprovar, usuarioAutenticadoId);

        if (!resultado.Resultado)
        {
            return BadRequest(resultado.Mensagem);
        }

        if (resultado.Objeto is not ResultadoPagamento resultadoPagamento)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível obter o resultado do pagamento");
        }

        var resposta = new PagamentoRespostaDTO
        {
            Status = resultadoPagamento.Status,
            CodigoTransacao = resultadoPagamento.CodigoTransacao,
            Mensagem = resultadoPagamento.Mensagem
        };

        return Ok(resposta);
    }


}
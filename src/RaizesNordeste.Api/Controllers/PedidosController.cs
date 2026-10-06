using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Application.Models;
using RaizesNordeste.Application.Servicos;
using RaizesNordeste.Domain.Enums;
using System.Security.Claims;
using RaizesNordeste.Api.Helpers;

[ApiController]
[Route("api/pedidos")]
[Produces("application/json")]
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
    [ProducesResponseType(typeof(PedidoCriadoDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CriarPedido(CriarPedidoDTO dto)
    {

        if (dto.CanalPedido == null)
        {
            return BadRequest(ErroRespostaHelper.RequisicaoInvalida("Canal de Pedido é obrigatório"));
        }

        var usuarioIdClaim = User.FindFirst("UsuarioId")?.Value;

        if (!long.TryParse(usuarioIdClaim, out var usuarioAutenticadoId))
        {
            return Unauthorized(ErroRespostaHelper.NaoAutenticado("Não foi possível identificar o usuário autenticado"));
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
            if (resultado.Mensagem == "Usuário inexistente" || resultado.Mensagem == "Unidade inválida" || resultado.Mensagem == "Produto inválido")
            {
                return NotFound(ErroRespostaHelper.NaoEncontrado(resultado.Mensagem));
            }

            if (resultado.Mensagem == "Usuário inválido para operação ou inativo" || resultado.Mensagem == "Cliente do pedido inválido")
            {
                return StatusCode(StatusCodes.Status403Forbidden, ErroRespostaHelper.AcessoNegado(resultado.Mensagem));
            }

            if (resultado.Mensagem == "Cliente inválido ou inativo" || resultado.Mensagem == "Estoque indisponível para o pedido")
            {
                return UnprocessableEntity(ErroRespostaHelper.RegraNegocio(resultado.Mensagem));
            }

            return BadRequest(ErroRespostaHelper.RequisicaoInvalida(resultado.Mensagem));
        }


        if (resultado.Objeto is not PedidoCriadoOutput pedidoOutput)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErroRespostaHelper.Criar(StatusCodes.Status500InternalServerError,
                "Erro interno", "Não foi possível obter os dados do pedido criado"));
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
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AlterarStatus(long id, AlterarStatusPedidoDTO dto)
    {

        var usuarioIdClaim = User.FindFirst("UsuarioId")?.Value;

        if (!long.TryParse(usuarioIdClaim, out var usuarioAutenticadoId))
        {
            return Unauthorized(ErroRespostaHelper.NaoAutenticado("Usuário autenticado inválido"));
        }

        var perfil = User.FindFirst(ClaimTypes.Role)?.Value;

        if (perfil == "CLIENTE" && dto.Status != StatusPedido.Cancelado)
        {
            return Forbid();
        }

        if (perfil != "CLIENTE" && perfil != "FUNCIONARIO" && perfil != "ADMIN" && perfil != "SISTEMA")
        {
            return Forbid();
        }

        var resultado = await _pedidoStatusService.AlterarStatus(id, dto.Status, usuarioAutenticadoId);

        if (!resultado)
        {
            return Conflict(ErroRespostaHelper.Conflito("Não foi possível alterar o status do pedido"));
        }

        return Ok("Status do pedido alterado com sucesso");

    }



    [Authorize(Roles = "ADMIN,FUNCIONARIO,CLIENTE")]
    [HttpPost("{id}/pagamentos")]
    [ProducesResponseType(typeof(PagamentoRespostaDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ProcessarPagamento(long id, ProcessarPagamentoDTO dto)
    {
        var usuarioIdClaim = User.FindFirst("UsuarioId")?.Value;

        if (!long.TryParse(usuarioIdClaim, out var usuarioAutenticadoId))
        {
            return Unauthorized(ErroRespostaHelper.NaoAutenticado("Não foi possível identificar o usuário autenticado"));
        }

        var aprovar = dto.Aprovar ?? true;

        var resultado = await _pagamentoService.ProcessarPagamento(id, dto.MetodoPagamento, aprovar, usuarioAutenticadoId);

        if (!resultado.Resultado)
        {
            if (resultado.Mensagem == "Pedido não encontrado")
            {
                return NotFound(ErroRespostaHelper.NaoEncontrado(resultado.Mensagem));
            }

            if (resultado.Mensagem == "O pedido não está aguardando pagamento")
            {
                return Conflict(ErroRespostaHelper.Conflito(resultado.Mensagem));
            }

            return BadRequest(ErroRespostaHelper.RequisicaoInvalida(resultado.Mensagem));
        }

        if (resultado.Objeto is not ResultadoPagamento resultadoPagamento)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErroRespostaHelper.Criar(StatusCodes.Status500InternalServerError,
    "Erro interno", "Não foi possível obter o resultado do pagamento"));
        }

        var resposta = new PagamentoRespostaDTO
        {
            Status = resultadoPagamento.Status,
            CodigoTransacao = resultadoPagamento.CodigoTransacao,
            Mensagem = resultadoPagamento.Mensagem
        };

        return Ok(resposta);
    }


    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PedidoCriadoDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ListarPedidos([FromQuery] CanalPedido? canalPedido, [FromQuery(Name = "status")] StatusPedido? statusPedido)
    {
        var usuarioIdClaim = User.FindFirst("UsuarioId")?.Value;

        if (!long.TryParse(usuarioIdClaim, out var usuarioAutenticadoId))
        {
            return Unauthorized(ErroRespostaHelper.NaoAutenticado("Não foi possível identificar o usuário autenticado"));
        }

        var resultado = await _pedidoService.ListarPedidos(usuarioAutenticadoId, canalPedido, statusPedido);

        if (!resultado.Resultado)
        {
            return BadRequest(ErroRespostaHelper.RequisicaoInvalida(resultado.Mensagem));
        }

        if (resultado.Objeto is not List<PedidoCriadoOutput> pedidosOutput)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErroRespostaHelper.Criar(StatusCodes.Status500InternalServerError, "Erro interno",
                "Não foi possível obter os pedidos"));
        }

        var pedidosDTO = new List<PedidoCriadoDTO>();

        foreach (var pedido in pedidosOutput)
        {
            var itensDTO = new List<PedidoItemRespostaDTO>();

            foreach (var item in pedido.Itens)
            {
                itensDTO.Add(new PedidoItemRespostaDTO
                {
                    Produto = item.Produto,
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario,
                    ValorTotal = item.ValorTotal
                });
            }

            pedidosDTO.Add(new PedidoCriadoDTO
            {
                Id = pedido.Id,
                Cliente = pedido.Cliente,
                Unidade = pedido.Unidade,
                CanalPedido = pedido.CanalPedido,
                Subtotal = pedido.Subtotal,
                Desconto = pedido.Desconto,
                ValorTotal = pedido.ValorTotal,
                Status = pedido.Status,
                DataCriacao = pedido.DataCriacao,
                Itens = itensDTO
            });
        }

        return Ok(pedidosDTO);
    }





    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PedidoCriadoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErroRespostaDTO), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarPedidoPorId(long id)
    {
        var usuarioIdClaim = User.FindFirst("UsuarioId")?.Value;

        if (!long.TryParse(usuarioIdClaim, out var usuarioAutenticadoId))
        {
            return Unauthorized(ErroRespostaHelper.NaoAutenticado("Não foi possível identificar o usuário autenticado"));
        }

        var resultado = await _pedidoService.BuscarPedidoPorId(id, usuarioAutenticadoId);

        if (!resultado.Resultado)
        {
            if (resultado.Mensagem == "Usuário não possui acesso a este pedido" ||
                resultado.Mensagem == "Não é possível realizar a operação")
            {
                return StatusCode(StatusCodes.Status403Forbidden,ErroRespostaHelper.AcessoNegado(resultado.Mensagem));
            }

            if (resultado.Mensagem == "Pedido não encontrado")
            {
                return NotFound(ErroRespostaHelper.NaoEncontrado(resultado.Mensagem));
            }

            return BadRequest(ErroRespostaHelper.RequisicaoInvalida(resultado.Mensagem));
        }

        if (resultado.Objeto is not PedidoCriadoOutput pedidoOutput)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,ErroRespostaHelper.Criar(StatusCodes.Status500InternalServerError,"Erro interno",
                    "Não foi possível obter os dados do pedido"));
        }

        var itensDTO = new List<PedidoItemRespostaDTO>();

        foreach (var item in pedidoOutput.Itens)
        {
            itensDTO.Add(new PedidoItemRespostaDTO
            {
                Produto = item.Produto,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario,
                ValorTotal = item.ValorTotal
            });
        }

        var pedidoDTO = new PedidoCriadoDTO
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
            Itens = itensDTO
        };

        return Ok(pedidoDTO);
    }




}
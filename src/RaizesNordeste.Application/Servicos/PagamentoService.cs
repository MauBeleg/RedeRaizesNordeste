using RaizesNordeste.Application.Gateways;
using RaizesNordeste.Application.Models;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Application.Services;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Servicos
{
    public class PagamentoService
    {
        private readonly IPagamentoGateway _pagamentoGateway;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly PedidoStatusService _pedidoStatusService;
        private readonly AuditoriaService _auditoriaService;

        public PagamentoService(IPagamentoGateway pagamentoGateway, IPedidoRepository pedidoRepository, IPagamentoRepository pagamentoRepository,
            PedidoStatusService pedidoStatusService, AuditoriaService auditoriaService)
        {
            _pagamentoGateway = pagamentoGateway;
            _pedidoRepository = pedidoRepository;
            _pagamentoRepository = pagamentoRepository;
            _pedidoStatusService = pedidoStatusService;
            _auditoriaService = auditoriaService;
        }

        public async Task<ResultadoOperacao> ProcessarPagamento(long pedidoId, MetodoPagamento metodoPagamento, bool aprovar, long usuarioAutenticadoId)
        {
            var pedido = await _pedidoRepository.BuscarPedidoPorId(pedidoId);

            if (pedido == null)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Pedido não encontrado"
                };
            }

            if (pedido.Status != StatusPedido.AguardandoPagamento)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "O pedido não está aguardando pagamento"
                };
            }

            var solicitacao = new SolicitacaoPagamento
            {
                Valor = pedido.ValorTotal,
                MetodoPagamento = metodoPagamento,
                Referencia = pedido.Id.ToString(),
            };

            var resultadoPagamento = await _pagamentoGateway.ProcessarPagamento(solicitacao, aprovar);


            var pagamento = new Pagamento
            {
                PedidoId = pedidoId,
                Status = resultadoPagamento.Status,
                FormaPagamento = metodoPagamento,
                Valor = pedido.ValorTotal,
                IdentificadorExterno = resultadoPagamento.CodigoTransacao,
                CriadoPor = usuarioAutenticadoId,
                DataCriacao = DateTime.UtcNow
            };


            await _pagamentoRepository.SalvarPagamento(pagamento);
            await _auditoriaService.Registrar(usuarioAutenticadoId, "PAGAMENTO_PROCESSADO", "PAGAMENTO", pagamento.Id, $"Status: {resultadoPagamento.Status}");

            if (resultadoPagamento.Status != StatusPagamento.Aprovado)
            {
                return new ResultadoOperacao
                {
                    Resultado = true,
                    Mensagem = "Pagamento processado",
                    Objeto = resultadoPagamento
                };
            }

            var statusAlterado = await _pedidoStatusService.AlterarStatus(pedidoId, StatusPedido.Recebido, usuarioAutenticadoId);

            if (!statusAlterado)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "O pagamento foi registrado, mas não foi possível alterar o seu status"
                };
            }

            
            return new ResultadoOperacao
            {
                Resultado = true,
                Mensagem = "Pagamento registrado",
                Objeto = resultadoPagamento
            };
           



        }
    }
}

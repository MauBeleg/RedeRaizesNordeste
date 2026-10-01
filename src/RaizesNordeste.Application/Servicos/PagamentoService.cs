using RaizesNordeste.Application.Gateways;
using RaizesNordeste.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Servicos
{
    public class PagamentoService
    {
        private readonly IPagamentoGateway _pagamentoGateway;

        public PagamentoService(IPagamentoGateway pagamentoGateway)
        {
            _pagamentoGateway = pagamentoGateway;
        }

        public Task<ResultadoPagamento> ProcessarPagamento(SolicitacaoPagamento solicitacao, bool aprovar)
        {
            return _pagamentoGateway.ProcessarPagamento(solicitacao, aprovar);
        }
    }
}

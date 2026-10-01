using RaizesNordeste.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Gateways
{
    public interface IPagamentoGateway
    {
        public Task<ResultadoPagamento> ProcessarPagamento(SolicitacaoPagamento solicitacao, bool aprovar);
    }
}

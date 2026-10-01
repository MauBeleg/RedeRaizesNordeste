using RaizesNordeste.Application.Gateways;
using RaizesNordeste.Application.Models;
using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Infrastructure.Gateways
{
    public class PagamentoMockGateway : IPagamentoGateway
    {
        public Task<ResultadoPagamento> ProcessarPagamento(
            SolicitacaoPagamento solicitacao, bool aprovar)
        {
            if (!aprovar)
            {
                return Task.FromResult(new ResultadoPagamento
                {
                    Status = StatusPagamento.Recusado,
                    CodigoTransacao = "MOCK-" + Guid.NewGuid(),
                    Mensagem = "Pagamento Recusado"
                });
            }
            else
            {
                return Task.FromResult(new ResultadoPagamento
                {
                    Status = StatusPagamento.Aprovado,
                    CodigoTransacao = "MOCK-" + Guid.NewGuid(),
                    Mensagem = "Pagamento Aprovado"
                });
            }
        }
    }
}
using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Repositories
{
    public interface IPagamentoRepository
    {
        public Task<Pagamento> SalvarPagamento (Pagamento pagamento);
    }
}

using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Infrastructure.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly ApplicationDbContext _context;


        public PagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pagamento> SalvarPagamento (Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            await _context.SaveChangesAsync();

            return pagamento;
        }
    }
}

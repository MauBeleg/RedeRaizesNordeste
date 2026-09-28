using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Infrastructure.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly ApplicationDbContext _context;


        public EstoqueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Produto?> BuscarProdutoComConsumo(long produtoId) //retorna os produtos com receita e sem receita (produtos unitários como água)
        {
            return await _context.Produtos.Include(p => p.Receita).ThenInclude(r => r!.Itens).ThenInclude(i => i.ItemInventario)
                .Include(p => p.ItensInventario).ThenInclude(pi => pi.ItemInventario).FirstOrDefaultAsync(p => p.Id == produtoId && p.Ativo);
        }

        public async Task<Estoque?> BuscarEstoqueDaUnidade(long unidadeId)
        {
            return await _context.Estoques.FirstOrDefaultAsync(e => e.UnidadeId == unidadeId);
        }

        public async Task<SaldoEstoque?> BuscarSaldo(long estoqueId, long itemInventarioId) //Busca o saldo disponível do estoque
        {
            return await _context.SaldosEstoque.FirstOrDefaultAsync(e => e.EstoqueId == estoqueId && e.ItemInventarioId == itemInventarioId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;
using RaizesNordeste.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;


namespace RaizesNordeste.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;


        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Pedido> SalvarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task<Pedido?> BuscarPedidoPorId(long id)
        {
            return await _context.Pedidos.Include(p => p.Cliente).Include(p => p.Unidade).Include(p => p.Itens).ThenInclude(pi => pi.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SalvarAlteracoes()
        {
            await _context.SaveChangesAsync();
        }
    



    public async Task<List<Pedido>> ListarPedidos(CanalPedido? canalPedido, StatusPedido? statusPedido, long? clienteId, long? unidadeId)
        {

            var query = _context.Pedidos.Include(p => p.Cliente).Include(p => p.Unidade).Include(p => p.Itens).ThenInclude(pi => pi.Produto).AsQueryable();

            if (canalPedido.HasValue)
            {
                query = query.Where(p => p.CanalPedido == canalPedido.Value);
            }
            if (statusPedido.HasValue)
            {
                query = query.Where(p => p.Status == statusPedido.Value);
            }
            if (clienteId.HasValue)
            {
                query = query.Where(p => p.ClienteId == clienteId.Value);
            }
            if (unidadeId.HasValue)
            {
                query = query.Where(p => p.UnidadeId == unidadeId.Value);
            }


            return await query.ToListAsync();
        }



    }

}

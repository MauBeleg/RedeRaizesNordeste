using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
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
            return await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SalvarAlteracoes()
        {
            await _context.SaveChangesAsync();
        }
    }
}

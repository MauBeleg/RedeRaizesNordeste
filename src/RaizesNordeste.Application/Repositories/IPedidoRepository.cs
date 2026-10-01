using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> SalvarPedido(Pedido pedido);

        Task<Pedido?> BuscarPedidoPorId (long id);

        Task SalvarAlteracoes();

    }
}

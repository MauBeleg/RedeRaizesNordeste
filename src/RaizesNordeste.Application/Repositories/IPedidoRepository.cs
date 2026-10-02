using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;
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

        Task<List<Pedido>> ListarPedidos(CanalPedido? canalPedido, StatusPedido? statusPedido, long? clienteId, long? unidadeId);

    }
}

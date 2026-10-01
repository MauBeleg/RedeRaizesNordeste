using RaizesNordeste.Domain.Enums;
using RaizesNordeste.Application.Repositories;
using System.ComponentModel.DataAnnotations;

namespace RaizesNordeste.Application.Servicos
{
    public class PedidoStatusService
    {

        private readonly IPedidoRepository _pedidoRepository;


        public PedidoStatusService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public bool PodeTransicionar(StatusPedido statusAtual,StatusPedido novoStatus)
        {
            return (statusAtual, novoStatus) switch
            {
                (StatusPedido.AguardandoPagamento, StatusPedido.Recebido) => true,
                (StatusPedido.AguardandoPagamento, StatusPedido.Cancelado) => true,
                (StatusPedido.Recebido, StatusPedido.EmPreparo) => true,
                (StatusPedido.Recebido, StatusPedido.Cancelado) => true,
                (StatusPedido.EmPreparo, StatusPedido.Pronto) => true,
                (StatusPedido.EmPreparo, StatusPedido.Cancelado) => true,
                (StatusPedido.Pronto, StatusPedido.Entregue) => true,

                _ => false
            };
        }


        public async Task<bool> AlterarStatus(long pedidoId, StatusPedido novoStatus)
        {
            var pedido = await _pedidoRepository.BuscarPedidoPorId(pedidoId);

            if (pedido == null)
            {
                return false;
            }

            var podeTransicionar = PodeTransicionar(pedido.Status, novoStatus);

            if (!podeTransicionar)
            {
                return false;
            }

            pedido.Status = novoStatus;

            await _pedidoRepository.SalvarAlteracoes();

            return true;


        }
    }
}
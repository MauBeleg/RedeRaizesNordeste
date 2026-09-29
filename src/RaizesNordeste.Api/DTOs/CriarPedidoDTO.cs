using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Api.DTOs
{
    public class CriarPedidoDTO
    {
        public long ClienteId { get; set; }
        public long UnidadeId { get; set; }
        public CanalPedido? CanalPedido { get; set; }
        public List<CriarPedidoItemDTO> Itens { get; set; } = new();
    }
}

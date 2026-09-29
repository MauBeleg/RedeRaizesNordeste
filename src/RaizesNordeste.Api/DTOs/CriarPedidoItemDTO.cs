using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Api.DTOs
{
    public class CriarPedidoItemDTO
    {
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}

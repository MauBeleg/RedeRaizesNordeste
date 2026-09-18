

namespace RaizesNordeste.Domain.Entities
{
    public class PedidoItem
    {
        public long Id { get; set; }
        public long PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
    }
}

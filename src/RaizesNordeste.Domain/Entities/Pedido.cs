using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Domain.Entities
{
    public class Pedido
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public Usuario Cliente { get; set; } = null!;
        public long UnidadeId { get; set; }
        public Unidade Unidade { get; set; } = null!;
        public CanalPedido CanalPedido { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedido Status { get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }

        public ICollection<PedidoItem> Itens { get; set; } = new List<PedidoItem>();

        public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    }
}

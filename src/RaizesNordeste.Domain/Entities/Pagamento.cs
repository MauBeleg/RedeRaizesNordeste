using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Domain.Entities
{
    public class Pagamento
    {
        public long Id { get; set; }
        public long PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public StatusPagamento Status { get; set; }
        public string FormaPagamento { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string? IdentificadorExterno {  get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
    }
}

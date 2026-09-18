using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Domain.Entities
{
    public class PontosHistorico
    {
        public long Id { get; set; }
        public long PontosClienteId { get; set; }
        public PontosCliente PontosCliente { get; set; } = null!;
        public long? PedidoId { get; set; }
        public Pedido? Pedido { get; set; }
        public long? RegraResgateId { get; set; }
        public RegraResgatePontos? RegraResgatePontos { get; set; }
        public TipoMovimentacaoPontos TipoMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
    }
}

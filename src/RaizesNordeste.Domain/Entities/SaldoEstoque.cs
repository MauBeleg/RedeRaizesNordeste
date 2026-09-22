

namespace RaizesNordeste.Domain.Entities
{
    public class SaldoEstoque
    {
        public long Id { get; set; }
        public long EstoqueId { get; set; }
        public Estoque Estoque { get; set; } = null!;
        public long ItemInventarioId { get; set; }
        public ItemInventario ItemInventario { get; set; } = null!;
        public int Quantidade { get; set; }
        public int QuantidadeReservada { get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
    }
}

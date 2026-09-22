

namespace RaizesNordeste.Domain.Entities
{
    public class ProdutoItemInventario
    {
        public long Id { get; set; }
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;
        public long ItemInventarioId { get; set; }
        public ItemInventario ItemInventario { get; set; } = null!;
        public int QuantidadeConsumo { get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
    }
}



namespace RaizesNordeste.Domain.Entities
{
    public class CardapioItem
    {
        public long Id { get; set; }
        public long CardapioId { get; set; }
        public Cardapio Cardapio { get; set; } = null!;
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;
        public bool Ativo {  get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
    }
}

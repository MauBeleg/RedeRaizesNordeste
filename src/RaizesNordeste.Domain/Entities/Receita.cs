
namespace RaizesNordeste.Domain.Entities
{
    public class Receita
    {
        public long Id { get; set; }
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public ICollection<ReceitaItem> Itens { get; set; } = new List<ReceitaItem>();
    }
}

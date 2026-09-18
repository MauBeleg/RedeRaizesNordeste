

namespace RaizesNordeste.Domain.Entities
{
    public class Cardapio
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public long UnidadeId { get; set; }
        public Unidade Unidade { get; set; } = null!;
        public bool Ativo {  get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public ICollection<CardapioItem> Itens { get; set; }= new List<CardapioItem>();
    }
}

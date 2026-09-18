
namespace RaizesNordeste.Domain.Entities
{
    public class Unidade
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public Cardapio Cardapio { get; set; } = null!;
        public Estoque Estoque { get; set; } = null!;
    }
}

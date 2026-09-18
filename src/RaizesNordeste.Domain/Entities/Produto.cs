using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Domain.Entities
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao {  get; set; }
        public decimal ValorUnitario { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo {  get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public Receita? Receita { get; set; }
        public ICollection<CardapioItem> CardapiosItens { get; set; } = new List<CardapioItem>();
        public ICollection<PedidoItem> PedidosItens { get; set; } = new List<PedidoItem>();
        public ICollection<ProdutoItemInventario> ItensInventario { get; set; } = new List<ProdutoItemInventario>();
    }
}



namespace RaizesNordeste.Domain.Entities
{
    public class ItemInventario
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string UnidadeMedida {  get; set; } = string.Empty;
        public string Tipo {  get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public ICollection<SaldoEstoque> SaldosEstoque { get; set; } = new List<SaldoEstoque>();
        public ICollection<ReceitaItem> ReceitasItens { get; set; } = new List<ReceitaItem>();
        public ICollection<ProdutoItemInventario> ProdutosItens { get; set; } = new List<ProdutoItemInventario>();
    }
}

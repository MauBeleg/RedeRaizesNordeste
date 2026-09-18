

namespace RaizesNordeste.Domain.Entities
{
    public class Estoque
    {
        public long Id { get; set; }
        public long UnidadeId { get; set; }
        public Unidade Unidade { get; set; } = null!;
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public ICollection<SaldoEstoque> Saldos { get; set; } = new List<SaldoEstoque>();
    }
}

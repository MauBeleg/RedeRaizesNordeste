
namespace RaizesNordeste.Domain.Entities
{
    public class RegraResgatePontos
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int PontosNecessarios { get; set; }
        public int PercentualDesconto { get; set; }
        public bool Ativo {  get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public ICollection<PontosHistorico> Historicos { get; set; } = new List<PontosHistorico>();
    }
}

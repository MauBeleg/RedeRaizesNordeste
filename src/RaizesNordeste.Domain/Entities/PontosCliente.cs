

namespace RaizesNordeste.Domain.Entities
{
    public class PontosCliente
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public Usuario Cliente { get; set; } = null!;
        public int Pontos {  get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public ICollection<PontosHistorico> Historicos { get; set; }= new List<PontosHistorico>();
    }
}

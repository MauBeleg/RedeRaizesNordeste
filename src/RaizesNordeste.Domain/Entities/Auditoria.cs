
namespace RaizesNordeste.Domain.Entities
{
    public class Auditoria
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public string Acao { get; set; } = string.Empty;
        public string Entidade { get; set; } =string.Empty;
        public long RegistroId { get; set; }
        public string? Detalhes { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}

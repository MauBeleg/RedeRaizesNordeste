

namespace RaizesNordeste.Domain.Entities
{
    public class Consentimento
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public string TipoConsentimento { get; set; } = string.Empty;
        public bool Aceito { get; set; }
        public long CriadoPor { get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
    }
}

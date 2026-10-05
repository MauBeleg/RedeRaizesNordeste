namespace RaizesNordeste.Api.DTOs
{
    public class ConsentimentoAdminRespostaDTO
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string TipoConsentimento { get; set; } = string.Empty;
        public bool Aceito { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
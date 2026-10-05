namespace RaizesNordeste.Api.DTOs
{
    public class ConsentimentoRespostaDTO
    {
        public long Id { get; set; }
        public string TipoConsentimento { get; set; } = string.Empty;
        public bool Aceito { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
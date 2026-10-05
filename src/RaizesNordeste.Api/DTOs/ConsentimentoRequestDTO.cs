namespace RaizesNordeste.Api.DTOs
{
    public class ConsentimentoRequestDTO
    {
        public string TipoConsentimento { get; set; } = string.Empty;
        public bool Aceito { get; set; }
    }
}
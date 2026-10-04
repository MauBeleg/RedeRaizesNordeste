namespace RaizesNordeste.Api.DTOs
{
    public class ErroRespostaDTO
    {
        public int Status {  get; set; }
        public string Erro { get; set; } = string.Empty;
        public string Mensagem {  get; set; } = string.Empty;
    }
}

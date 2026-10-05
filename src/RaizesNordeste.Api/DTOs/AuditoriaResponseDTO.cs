namespace RaizesNordeste.Api.DTOs
{
    public class AuditoriaRespostaDTO
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Acao { get; set; } = string.Empty;
        public string Entidade { get; set; } = string.Empty;
        public long RegistroId { get; set; }
        public string? Detalhes { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
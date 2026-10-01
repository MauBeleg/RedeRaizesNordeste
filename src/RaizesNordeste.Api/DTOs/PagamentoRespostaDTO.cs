using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Api.DTOs
{
    public class PagamentoRespostaDTO
    {
        public StatusPagamento Status { get; set; }
        public string CodigoTransacao { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
    }
}
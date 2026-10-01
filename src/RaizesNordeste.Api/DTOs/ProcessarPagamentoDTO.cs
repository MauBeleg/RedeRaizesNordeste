using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Api.DTOs
{
    public class ProcessarPagamentoDTO
    {
        public MetodoPagamento MetodoPagamento { get; set; }
        public bool? Aprovar { get; set; }
    }
}

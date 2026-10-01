using RaizesNordeste.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Models
{
    public class SolicitacaoPagamento
    {
        public decimal Valor {  get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
        public string Referencia { get; set; } = string.Empty;
    }
}

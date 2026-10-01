using RaizesNordeste.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Models
{
    public class ResultadoPagamento
    {
        public StatusPagamento Status {  get; set; }
        public string CodigoTransacao {  get; set; } = string.Empty;
        public string Mensagem {  get; set; } = string.Empty;
    }
}

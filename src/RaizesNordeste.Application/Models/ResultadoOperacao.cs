using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Models
{
    public class ResultadoOperacao
    {
        public bool Resultado {  get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public object? Objeto { get; set; }
    }
}

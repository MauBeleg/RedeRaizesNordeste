using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Models
{
    public class CriarPedidoItemInput
    {
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}

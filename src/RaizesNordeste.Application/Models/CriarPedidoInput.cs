using RaizesNordeste.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Models
{
    public class CriarPedidoInput
    {
        public long ClienteId { get; set; }
        public long UnidadeId { get; set; }
        public CanalPedido CanalPedido { get; set; }
        public long UsuarioAutenticadoId { get; set; }
        public List<CriarPedidoItemInput> Itens { get; set; } = new();
    }
}

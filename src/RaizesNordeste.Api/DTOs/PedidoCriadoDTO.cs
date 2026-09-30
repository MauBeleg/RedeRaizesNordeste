using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Api.DTOs
{
    public class PedidoCriadoDTO
    {
        public long Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Unidade { get; set; } = string.Empty;
        public CanalPedido CanalPedido { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedido Status {  get; set; }
        public DateTime DataCriacao { get; set; }
        public List<PedidoItemRespostaDTO> Itens { get; set; } = new();
    }
}

namespace RaizesNordeste.Application.Models
{
    public class PedidoItemOutput
    {
        public string Produto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
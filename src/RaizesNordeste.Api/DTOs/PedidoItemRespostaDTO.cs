namespace RaizesNordeste.Api.DTOs
{
    public class PedidoItemRespostaDTO
    {
        public string Produto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}

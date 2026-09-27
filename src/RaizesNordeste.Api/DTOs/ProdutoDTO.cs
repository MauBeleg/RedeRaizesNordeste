namespace RaizesNordeste.Api.DTOs
{
    public class ProdutoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}

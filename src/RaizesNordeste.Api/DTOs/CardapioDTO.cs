namespace RaizesNordeste.Api.DTOs
{
    public class CardapioDTO
    {

        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public long UnidadeId { get; set; }
        public List<ProdutoDTO> Produtos { get; set; } = new();


    }
}

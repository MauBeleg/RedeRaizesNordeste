namespace RaizesNordeste.Api.DTOs
{
    public class CriarClienteDTO
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
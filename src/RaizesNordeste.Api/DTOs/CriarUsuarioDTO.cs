using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Api.DTOs
{
    public class CriarUsuarioDTO
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }

        public int? PerfilId { get; set; }
        public int? UnidadeId { get; set; }
        public SetorFuncionario? Setor { get; set; }
    }
}

using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Api.DTOs
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long PerfilId { get; set; }
        public long? UnidadeId { get; set; }
        public SetorFuncionario? Setor { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}

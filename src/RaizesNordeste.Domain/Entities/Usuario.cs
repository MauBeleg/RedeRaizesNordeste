
namespace RaizesNordeste.Domain.Entities
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public long PerfilId { get; set; }
        public Perfil Perfil { get; set; } = null!;
        public long? UnidadeId {  get; set; }
        public Unidade? Unidade { get; set; }
        public bool Ativo {  get; set; }
        public long? CriadoPor {  get; set; }
        public Usuario? UsuarioCriador { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<Consentimento> Consentimentos { get; set; } = new List<Consentimento>();
        public ICollection<PontosCliente> PontosClientes { get; set; } = new List<PontosCliente>();
        public ICollection<Auditoria> Auditorias { get; set; } = new List<Auditoria>();
    }
}

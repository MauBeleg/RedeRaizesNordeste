

namespace RaizesNordeste.Domain.Entities
{
    public class ReceitaItem
    {
        public long Id { get; set; }
        public long ReceitaId { get; set; }
        public Receita Receita { get; set; } = null!;
        public long ItemInventarioId { get; set; }
        public ItemInventario ItemInventario { get; set; } = null!;
        public int Quantidade { get; set; }
        public long CriadoPor {  get; set; }
        public Usuario UsuarioCriador { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
    }
}

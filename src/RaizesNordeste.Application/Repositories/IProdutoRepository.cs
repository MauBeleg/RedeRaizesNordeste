using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Application.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto?> BuscarProdutoPorId(long produtoId);
    }
}
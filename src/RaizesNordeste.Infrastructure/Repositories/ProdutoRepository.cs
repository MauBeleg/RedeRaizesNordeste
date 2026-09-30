using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Infrastructure.Persistence;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Produto?> BuscarProdutoPorId(long produtoId)
    {
        return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == produtoId && p.Ativo);
    }
}
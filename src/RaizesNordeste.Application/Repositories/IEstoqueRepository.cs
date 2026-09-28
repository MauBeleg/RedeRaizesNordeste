using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Repositories
{
    public interface IEstoqueRepository
    {

        Task<Produto?> BuscarProdutoComConsumo(long produtoId);

        Task<Estoque?> BuscarEstoqueDaUnidade(long unidadeId);

        Task<SaldoEstoque?> BuscarSaldo(long estoqueId, long itemInventarioId);

    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;


namespace RaizesNordeste.Infrastructure.Repositories
{
    public class CardapioRepository : ICardapioRepository
    {
        private readonly ApplicationDbContext _context;

        public CardapioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cardapio?> BuscarCardapioPorUnidade (long unidadeId)
        {
            var cardapio = await _context.Cardapios.Include(c => c.Itens).ThenInclude(i => i.Produto).FirstOrDefaultAsync(c => c.UnidadeId == unidadeId && c.Ativo);

            return cardapio;
        }

    }
}

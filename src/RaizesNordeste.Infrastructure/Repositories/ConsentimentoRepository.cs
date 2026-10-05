using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Infrastructure.Persistence;

namespace RaizesNordeste.Infrastructure.Repositories
{
    public class ConsentimentoRepository : IConsentimentoRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsentimentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SalvarConsentimento(Consentimento consentimento)
        {
            await _context.Consentimentos.AddAsync(consentimento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Consentimento>> ListarPorUsuario(long usuarioId)
        {
            return await _context.Consentimentos.AsNoTracking().Where(c => c.UsuarioId == usuarioId).OrderByDescending(c => c.DataCriacao).ToListAsync();
        }

        public async Task<List<Consentimento>> ListarTodos(long? usuarioId)
        {
            var query = _context.Consentimentos.Include(c => c.Usuario).AsNoTracking().AsQueryable();

            if (usuarioId.HasValue)
            {
                query = query.Where(c =>c.UsuarioId == usuarioId.Value);
            }

            return await query.OrderByDescending(c => c.DataCriacao).ToListAsync();
        }
    }
}
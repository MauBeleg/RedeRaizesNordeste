using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Infrastructure.Repositories
{
    public class AuditoriaRepository : IAuditoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public AuditoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SalvarAuditoria(Auditoria auditoria)
        {
            await _context.Auditorias.AddAsync(auditoria);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Auditoria>> ListarAuditorias(long? usuarioId, string? acao, string? entidade, long? registroId)
        {
            var query = _context.Auditorias.Include(a => a.Usuario).AsNoTracking().AsQueryable();

            if (usuarioId.HasValue)
            {
                query = query.Where(a => a.UsuarioId == usuarioId.Value);
            }

            if (!string.IsNullOrWhiteSpace(acao))
            {
                query = query.Where(a => a.Acao == acao);
            }

            if (!string.IsNullOrWhiteSpace(entidade))
            {
                query = query.Where(a => a.Entidade == entidade);
            }

            if (registroId.HasValue)
            {
                query = query.Where(a => a.RegistroId == registroId.Value);
            }

            return await query.OrderByDescending(a => a.DataCriacao).ToListAsync();
        }


    }
}
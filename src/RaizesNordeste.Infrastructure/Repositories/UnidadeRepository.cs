using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Infrastructure.Persistence;
using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RaizesNordeste.Infrastructure.Repositories
{
    public class UnidadeRepository : IUnidadeRepository
    {
        private readonly ApplicationDbContext _context;

        public UnidadeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Unidade>> BuscarUnidadesAtivas()
        {
            return await _context.Unidades.Where(u => u.Ativo).ToListAsync();
        }


        public async Task<Unidade?> BuscarUnidadePorId(long id)
        {
            return await _context.Unidades.FirstOrDefaultAsync(u => u.Id == id && u.Ativo);
        }
    }
}

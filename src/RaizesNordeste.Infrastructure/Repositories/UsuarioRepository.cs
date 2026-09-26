using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Infrastructure.Persistence;

namespace RaizesNordeste.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Verififica se email já existe no BD
        public async Task<bool> VerificarEmail(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        //Cria Usuário
        public async Task CreateUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        //Busca usuário pelo email para autenticação
        public async Task<Usuario?> BuscarUsuarioPorEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }


    }
}
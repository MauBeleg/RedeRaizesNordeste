using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Repositories
{
    public interface IUsuarioRepository
    {


         Task<bool> VerificarEmail(string email);
        Task<bool> VerificarCpf(string cpf);
        Task CreateUsuario(Usuario usuario);
        Task<Usuario?> BuscarUsuarioPorEmail(string email);
        Task<List<Usuario>> BuscarUsuarios();
        Task<Usuario?> BuscarUsuarioPorId (long  id);


    }
}

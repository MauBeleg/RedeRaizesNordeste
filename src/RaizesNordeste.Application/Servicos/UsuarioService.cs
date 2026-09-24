using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Application.Security;
using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Servicos
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaHasher _senhaHasher;

        public UsuarioService(
            IUsuarioRepository usuarioRepository, ISenhaHasher senhaHasher)
        {
            _usuarioRepository = usuarioRepository;
            _senhaHasher = senhaHasher;
        }

        //metodos do service de usuários

        public async Task<bool> CriarCliente(string nome, string email, string senha)
        {
            
            var exists = await _usuarioRepository.VerificarEmail(email);
            if (exists == true)
            {
                return false;
            }


            var usuario = new Usuario()
            {
                Nome = nome,
                Email = email,
                SenhaHash = _senhaHasher.GerarHash(senha),
                PerfilId = 3,
                Ativo = true
            };


            await _usuarioRepository.CreateUsuario(usuario);

            return true;

        }

    }
}

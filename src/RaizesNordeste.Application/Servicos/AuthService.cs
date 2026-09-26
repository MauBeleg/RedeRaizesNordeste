using System;
using System.Collections.Generic;
using System.Text;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Application.Security;

namespace RaizesNordeste.Application.Servicos
{
    public class AuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaHasher _senhaHasher;
        private readonly ITokenService _tokenService;


        public AuthService(
            IUsuarioRepository usuarioRepository,
            ISenhaHasher senhaHasher,
            ITokenService tokenService
            )
        {
            _usuarioRepository = usuarioRepository;
            _senhaHasher = senhaHasher;
            _tokenService = tokenService;
        }
            
        public async Task<string> Login (string email, string senha)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorEmail(email);

            if (usuario == null || !usuario.Ativo)
            {
                return null;
            }

            var senhaValida = _senhaHasher.VerificarSenha(usuario.SenhaHash, senha);

            if (!senhaValida)
            {
                return null;
            }

            return _tokenService.GerarToken(usuario);
        }

    }
}

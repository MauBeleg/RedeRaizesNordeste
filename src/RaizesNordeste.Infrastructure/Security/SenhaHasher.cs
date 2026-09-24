using RaizesNordeste.Application.Security;
using RaizesNordeste.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Infrastructure.Security
{
    public class SenhaHasher : ISenhaHasher
    {
        public string GerarHash(string senha)
        {
            var hasher = new PasswordHasher<string>();

            return hasher.HashPassword(null!, senha);
        }

        public bool VerificarSenha(string hash, string senha)
        {
            var hasher = new PasswordHasher<string>();
            var result = hasher.VerifyHashedPassword(null!, hash, senha);

            return result != PasswordVerificationResult.Failed;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Security
{
    public interface ISenhaHasher
    {
        string GerarHash(string senha);
        bool VerificarSenha(string hash, string senha);
    }
}
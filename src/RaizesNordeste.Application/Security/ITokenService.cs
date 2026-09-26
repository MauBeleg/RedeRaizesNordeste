using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Security
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}

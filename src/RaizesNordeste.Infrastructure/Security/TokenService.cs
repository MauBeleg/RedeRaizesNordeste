using RaizesNordeste.Application.Security;
using System;
using System.Collections.Generic;
using System.Text;
using RaizesNordeste.Domain.Entities;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace RaizesNordeste.Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        //defiine as configs de Jwt
        private readonly JwtSettings _settings;
        public TokenService(IOptions<JwtSettings> options) { 
            _settings = options.Value; 
        }


        public string GerarToken (Usuario usuario)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim("UsuarioId", usuario.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claims.Add(new Claim("PerfilId", usuario.PerfilId.ToString()));

            var chave = new SymmetricSecurityKey(Convert.FromBase64String(_settings.Chave));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            //Cria o token
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer, //Quem emitiu
                audience: _settings.Audience, //A quem pertence
                claims: claims, //Caims
                expires: DateTime.UtcNow.AddMinutes(_settings.ExpiracaoMinutos), //Tempo de expiração
                signingCredentials: credenciais //credenciais
                );

            var handler = new JwtSecurityTokenHandler(); //objeto para transformar o token em string

            return handler.WriteToken(token);
        }
    }
}

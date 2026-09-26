using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Infrastructure.Security
{
    public class JwtSettings
    {
        public string Chave {  get; set; } = string.Empty;
        public string Issuer {  get; set; } = string.Empty;
        public string Audience {  get; set; } = string.Empty;
        public int ExpiracaoMinutos { get; set; }
    }
}

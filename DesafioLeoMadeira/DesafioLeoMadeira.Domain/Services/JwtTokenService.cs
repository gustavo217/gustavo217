using DesafioLeoMadeira.ViewObject;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioLeoMadeira.Domain.Services
{
    public static class JwtTokenService
    {
        public static UsuarioVO GerarToken(UsuarioVO usuario)
        {

            var tokenHandler = new JwtSecurityTokenHandler();


            UsuarioVO u = new UsuarioVO();

            u.Usuario = usuario.Usuario;
            u.DataExpiracaoToken = DateTime.UtcNow.AddMinutes(5); 
            
            //chave secreta, geralmente se coloca em arquivo de configuração
            var key = Encoding.ASCII.GetBytes("ABhRTYUjHGEmKLOP124456tYSDFRETA,");
           
            var tokenDescriptor = new SecurityTokenDescriptor
            { 
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Usuario),
                    new Claim(ClaimTypes.Role, "1")
                }),
                Expires = u.DataExpiracaoToken,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            u.Token = tokenHandler.WriteToken(token);

            return u;

        }        
    }
}

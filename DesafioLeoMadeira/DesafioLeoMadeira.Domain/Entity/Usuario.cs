using DesafioLeoMadeira.Domain.Services;
using DesafioLeoMadeira.ViewObject;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace DesafioLeoMadeira.Domain.Entity
{
    public class Usuario
    {

        public UsuarioVO GerarToken(UsuarioVO usuario)
        {
            try
            {
                if (SenhaValida(usuario.Senha))
                {
                    UsuarioVO usu = JwtTokenService.GerarToken(usuario);
                    return usu;
                }

                else
                    throw new ApplicationException("Senha inválida, sua senha deve conter 15 cartecteres, ao menos uma letra maiuscula, uma letra minuscula, 1 numero e um caracter especial. Não pode haver caracteres repetidos em sequencia");

            }
            catch
            {
                throw;
            }

        }

        public void CriarSenha(string senha)
        {

            try
            {
                if (!SenhaValida(senha))
                    throw new ApplicationException("Senha invalida");
            }

            catch
            {
                throw;
            }


        }


        public bool SenhaValida(string senha)
        {

            string expressao = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{15}$";


            Regex er = new Regex(expressao, RegexOptions.None);


            if (er.IsMatch(senha))

            {


                for (int i = 0; i < 15; i++)
                {

                    if (i == 14)
                        break;

                    string carac1 = senha.Substring(i, 1);
                    string carac2 = senha.Substring(i + 1, 1);

                    if (carac1 == carac2)
                        return false;



                }

                return true;
            }

            else
                return false;

        }


    }
}

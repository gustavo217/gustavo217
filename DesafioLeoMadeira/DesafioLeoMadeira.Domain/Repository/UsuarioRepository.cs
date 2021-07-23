using DesafioLeoMadeira.Domain.Entity;
using DesafioLeoMadeira.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioLeoMadeira.Domain.Repository
{
    public class UsuarioRepository
    {
        Usuario usu = new Usuario();

        public UsuarioVO GerarToken(UsuarioVO usuario)
        {                        
            return usu.GerarToken(usuario);
        }


        public void CriarSenha(string senha)
        {

            try
            {
                usu.CriarSenha(senha);
            }

            catch
            {
                throw;
            }


        }
       public bool SenhaValida(string senha)
        {
            return usu.SenhaValida(senha);
        }

    }
}

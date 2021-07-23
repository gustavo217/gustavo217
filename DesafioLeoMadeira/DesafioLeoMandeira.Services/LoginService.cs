using DesafioLeoMadeira.Domain.Repository;
using DesafioLeoMadeira.ViewObject;
using System;
using System.Collections.Generic;

namespace DesafioLeoMandeira.Services
{
    public class LoginService : BaseServices
    {
        UsuarioRepository repo = new UsuarioRepository();

        public UsuarioVO obj { get; set; }

      
        public UsuarioVO GerarToken(UsuarioVO usuario)
        {

            return repo.GerarToken(usuario);

        }


        public void CriarSenha(string senha)
        {

            try
            {
                repo.CriarSenha(senha);
            }

            catch
            {
                throw;
            }


        }

        public bool SenhaValida(string senha)
        {
            return repo.SenhaValida(senha);
        }

    }
}

using DesafioLeoMadeira.ViewObject;
using DesafioLeoMandeira.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesafioLeoMadeiraTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GerarTokenValido()
        {

            try
            {

                UsuarioVO usu = new UsuarioVO();

                usu.Usuario = "gustavo";
                usu.Senha = "Gustavo@lmeida1";


                LoginService ls = new LoginService();

                usu = ls.GerarToken(usu);
            }
            catch
            {
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GerarTokenSenhaInvalida()
        {

            try
            {

                UsuarioVO usu = new UsuarioVO();

                usu.Usuario = "gustavo";
                usu.Senha = "Gustavda1";

                LoginService ls = new LoginService();

                usu = ls.GerarToken(usu);
            }
            catch
            {
                throw;
            }

        }

        [TestMethod]
        public void CriarSenhaValida()
        {

            try
            {                

                LoginService ls = new LoginService();

                ls.CriarSenha("Gustavo@lmeida1");
            }
            catch
            {
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CriarSenhaInValida()
        {

            try
            {

                LoginService ls = new LoginService();

                ls.CriarSenha("Gus");
            }
            catch
            {
                throw;
            }

        }
    }
}

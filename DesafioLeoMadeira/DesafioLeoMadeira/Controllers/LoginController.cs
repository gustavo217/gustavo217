using DesafioLeoMadeira.ViewObject;
using DesafioLeoMandeira.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioLeoMadeira.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {



        [HttpGet]
        [AllowAnonymous]
        [Route("iniciar")]
        public string Iniciar()
        {

            return "ok";

        }


        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public IActionResult CriarToken(UsuarioVO usuario)
            
        {

            try
            {
                LoginService service = new LoginService();

                usuario = service.GerarToken(usuario);

                return Ok(usuario);
            }

            catch (Exception err)
            {

                return BadRequest(err.Message);
            }

        }


        [HttpPost]
        [Route("criarsenha")]
        [Authorize]        
        public IActionResult CriarSenha([FromBody] string senha)
        {

            try
            {

                LoginService ls = new LoginService();

                ls.CriarSenha(senha);

                return Ok("Sua senha foi criaca com sucesso.");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

        }


        [HttpPost]
        [Route("validar")]
        [Authorize]
        public IActionResult ValidarSenha([FromBody] string senha)
        {

            try
            {

                LoginService ls = new LoginService();
                
                return Ok(ls.SenhaValida(senha));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

        }

    }
}

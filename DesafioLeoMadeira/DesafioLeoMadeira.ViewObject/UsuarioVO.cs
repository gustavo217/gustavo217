using System;
using System.Runtime.Serialization;

namespace DesafioLeoMadeira.ViewObject
{

    [DataContract]
    public class UsuarioVO : BaseVO
    {

        public UsuarioVO()
        {

        }

        [DataMember(Name = "usuario")]
        public string Usuario { get; set; }


        [DataMember(Name = "senha")]
        public string Senha { get; set; }

        public string Token { get; set; }

        public DateTime DataExpiracaoToken { get; set; }

    }
            
}

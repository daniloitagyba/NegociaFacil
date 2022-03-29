using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Models.User
{
    public class LoginRequestModel
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}

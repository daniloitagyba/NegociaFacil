using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Application.Models.User
{
    public class LoginViewModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

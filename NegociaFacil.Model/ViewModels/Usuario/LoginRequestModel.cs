using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Model.ViewModels.Usuario
{
    public class LoginRequestModel
    {
        //[Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}

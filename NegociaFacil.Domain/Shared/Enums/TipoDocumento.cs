using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Shared.Enums
{
    public class TipoDocumento : Enumeration
    {
        public static readonly TipoDocumento Cpf = new(1, "CPF");
        public static readonly TipoDocumento Cnpj = new(2, "CNPJ");

        public TipoDocumento(int id, string name) : base(id, name)
        {
        }
    }
}

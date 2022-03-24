using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Entities
{
    public class Devedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
    }
}

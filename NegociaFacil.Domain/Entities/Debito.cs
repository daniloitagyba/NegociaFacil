﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Entities
{
    public class Debito
    {
        public Guid Id { get; set; }
        public Credor Credor { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
    }
}

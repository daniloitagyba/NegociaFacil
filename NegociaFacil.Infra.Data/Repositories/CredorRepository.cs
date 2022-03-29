using NegociaFacil.Domain.Entities;
using NegociaFacil.Domain.Repositories;
using NegociaFacil.Infra.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Infra.Data.Repositories
{
    public class CredorRepository : RepositoryBase<Credor>, ICredorRepository
    {
        public CredorRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICredorRepository Credores { get; }
        void SaveChanges();
    }
}

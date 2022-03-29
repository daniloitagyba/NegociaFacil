using NegociaFacil.Domain.Repositories;
using NegociaFacil.Infra.Data.DBContext;
using System;

namespace NegociaFacil.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public ICredorRepository Credores { get; }


        public UnitOfWork(ApplicationContext context, ICredorRepository credores)
        {
            _context = context;
            Credores = credores;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                    _context.Dispose();
                
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

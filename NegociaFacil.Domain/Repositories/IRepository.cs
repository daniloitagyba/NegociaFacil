using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity payment);
        Task SaveChangesAsync();
    }
}

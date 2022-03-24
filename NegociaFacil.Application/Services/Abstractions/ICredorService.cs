using NegociaFacil.Application.Models.Credor;
using NegociaFacil.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Application.Services.Abstractions
{
    public interface ICredorService 
    {
        Task AddAsync(CredorRequestModel requestModel);
        void Update(CredorRequestModel requestModel);
        void Remove(CredorRequestModel requestModel);
        Task<CredorViewModel> FindByIdAsync(Guid id);
        Task<IEnumerable<CredorViewModel>> GetAllAsync();
    }
}

using NegociaFacil.Models.Credor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NegociaFacil.Application.Services.Abstractions
{
    public interface ICredorService 
    {
        Task AddAsync(CredorRequestModel requestModel);
        void Update(CredorRequestModel requestModel);
        void Remove(CredorRequestModel requestModel);
        Task<CredorResponseModel> FindByIdAsync(Guid id);
        Task<IEnumerable<CredorResponseModel>> GetAllAsync();
    }
}

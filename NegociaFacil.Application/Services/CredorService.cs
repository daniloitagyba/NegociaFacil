using NegociaFacil.Application.Models.Credor;
using NegociaFacil.Application.Services.Abstractions;
using NegociaFacil.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Application.Services
{
    public class CredorService : ICredorService
    {
        private readonly ICredorRepository _credorRepository;

        public CredorService(ICredorRepository credorRepository)
        {
            _credorRepository = credorRepository ?? throw new ArgumentNullException(nameof(credorRepository));
        }

        public Task AddAsync(CredorRequestModel requestModel)
        {
            throw new NotImplementedException();
            //await _credorRepository.AddAsync(requestModel);
        }

        public void Update(CredorRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(CredorRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CredorViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CredorViewModel> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

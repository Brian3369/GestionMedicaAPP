using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Application.Response.Insurance.InsuranceProvider;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.Insurance
{
    public class InsuranceProviderService : IInsuranceProvidersService
    {
        private readonly IInsuranceProvidersRepository _insuranceProvidersRepository;
        private readonly ILogger<InsuranceProviderService> _logger;
        public InsuranceProviderService(IInsuranceProvidersRepository insuranceProvidersRepository, ILogger<InsuranceProviderService> logger)
        {
            _logger = logger;
            _insuranceProvidersRepository = insuranceProvidersRepository;
        }
        public Task<InsuranceProviderResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<InsuranceProviderResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<InsuranceProviderResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<InsuranceProviderResponse> SaveAsync(InsuranceProviderSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<InsuranceProviderResponse> UpdateAsync(InsuranceProviderUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

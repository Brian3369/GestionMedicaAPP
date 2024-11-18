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
        public async Task<InsuranceProviderResponse> GetAll()
        {
            InsuranceProviderResponse InsuranceProvidersResponse = new InsuranceProviderResponse();

            try
            {
                var result = await _insuranceProvidersRepository.GetAll();

                if (!result.Success)
                {
                    InsuranceProvidersResponse.Message = result.Message;
                    InsuranceProvidersResponse.IsSuccess = result.Success;
                    return InsuranceProvidersResponse;
                }

                InsuranceProvidersResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                InsuranceProvidersResponse.IsSuccess = false;
                InsuranceProvidersResponse.Model = "Error obteniendo los provedores de seguro";
                _logger.LogError(InsuranceProvidersResponse.Message, ex.ToString());
            }

            return InsuranceProvidersResponse;
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

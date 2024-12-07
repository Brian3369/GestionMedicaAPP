using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Base.Insurance.InsuranceProviders
{
    public class InsuranceProvidersApiService : IInsuranceProvidersApiService
    {
        private readonly IInsuranceProvidersRepository _repository;

        public InsuranceProvidersApiService(IInsuranceProvidersRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<InsuranceProviderBaseDto>> GetAllAsync() => _repository.GetAllAsync();

        public Task<InsuranceProviderBaseDto> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<BaseApiResponse> CreateAsync(InsuranceProviderSaveDto dto) => _repository.CreateAsync(dto);

        public Task<BaseApiResponse> UpdateAsync(int id, InsuranceProviderSaveDto dto) => _repository.UpdateAsync(id, dto);

        public Task<BaseApiResponse> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

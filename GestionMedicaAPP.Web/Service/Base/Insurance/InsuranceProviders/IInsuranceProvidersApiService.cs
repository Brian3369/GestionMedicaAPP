using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Base.Insurance.InsuranceProviders
{
    public interface IInsuranceProvidersApiService
    {
        Task<IEnumerable<InsuranceProviderBaseDto>> GetAllAsync();
        Task<InsuranceProviderBaseDto> GetByIdAsync(int id);
        Task<BaseApiResponse> CreateAsync(InsuranceProviderSaveDto dto);
        Task<BaseApiResponse> UpdateAsync(int id, InsuranceProviderSaveDto dto);
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}

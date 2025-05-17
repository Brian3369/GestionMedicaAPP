using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Web.Models.ControllersModels.Insurance.InsuranceProviders;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.Insurance
{
    public interface IInsuranceProvidersServiceApi : IBaseServiceApi<InsuranceProviderGetAllModel, InsuranceProviderGetByIdModel, InsuranceProviderSaveDto, InsuranceProviderUpdateDto>
    {
    }
}

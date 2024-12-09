using GestionMedicaAPP.Persistance.Models.Insurance;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Insurance.InsuranceProviders
{
    public class InsuranceProviderGetByIdModel : BaseApiResponse
    {
        public InsuranceProvidersModel model { get; set; }
    }
}

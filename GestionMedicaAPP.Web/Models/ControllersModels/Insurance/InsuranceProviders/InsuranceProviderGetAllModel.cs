using GestionMedicaAPP.Persistance.Models.Insurance;
using GestionMedicaAPP.Web.Models.Base;


namespace GestionMedicaAPP.Web.Models.ControllersModels.Insurance.InsuranceProviders
{
    public class InsuranceProviderGetAllModel : BaseApiResponse
    {
        public List<InsuranceProvidersModel> model { get; set; }
    }
}

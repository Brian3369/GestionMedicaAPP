using GestionMedicaAPP.Persistance.Models.Insurance;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.Insurance.InsuranceProviders
{
    public class InsuranceProvidersGetByIdModel : BaseApiResponse
    {
        public InsuranceProvidersModel model {  get; set; }
    }
}

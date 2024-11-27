using GestionMedicaAPP.Persistance.Models.Insurance;
using GestionMedicaAPP.Web.Models.Base;


namespace GestionMedicaAPP.Web.Models.Insurance.InsuranceProviders
{
    public class InsuranceProvidersGetAllModel : BaseApiResponse
    {
        public List<InsuranceProvidersModel> model { get; set; }
    }
}

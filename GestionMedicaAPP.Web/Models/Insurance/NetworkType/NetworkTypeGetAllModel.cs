using GestionMedicaAPP.Persistance.Models.Insurance;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.Insurance.NetworkType
{
    public class NetworkTypeGetAllModel : BaseApiResponse
    {
        public List<NetworkTypeModel> model { get; set; }
    }
}

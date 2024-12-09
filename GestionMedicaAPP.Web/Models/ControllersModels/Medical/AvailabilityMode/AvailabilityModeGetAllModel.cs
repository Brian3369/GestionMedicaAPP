using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Persistance.Models.Medical;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Medical.AvailabilityMode
{
    public class AvailabilityModeGetAllModel : BaseApiResponse
    {
        public List<AvailabilityModesModel> model { get; set; }
    }
}

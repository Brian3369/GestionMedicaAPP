using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Persistance.Models.Medical;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Medical.AvailabilityModes
{
    public class AvailabilityModeGetByIdModel : BaseApiResponse
    {
        public AvailabilityModesModel model { get; set; }
    }
}

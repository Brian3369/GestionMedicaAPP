using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.appointments.DoctorAvailability
{
    public class DoctorAvailabilityGetAllModel : BaseApiResponse
    {
        public List<DoctorAvailabilityModel> model { get; set; }
    }
}

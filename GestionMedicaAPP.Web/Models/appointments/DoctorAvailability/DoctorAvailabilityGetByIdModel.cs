using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.appointments.DoctorAvailability
{
    public class DoctorAvailabilityGetByIdModel : BaseApiResponse
    {
        public DoctorAvailabilityModel model { get; set; }
    }
}

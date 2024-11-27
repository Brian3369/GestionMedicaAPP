using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.appointments.DoctorAvailability
{
    public class DoctorAvailabilityGetAllModel : BaseApiResponse
    {
        public List<DoctorAvailabilityModel> model {  get; set; }
    }
}

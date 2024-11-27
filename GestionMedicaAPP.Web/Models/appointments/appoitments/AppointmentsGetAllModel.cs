using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.appointments.appoitments
{
    public class AppointmentsGetAllModel : BaseApiResponse
    {
        public List<AppointmentsModel> model { get; set; }
    }
}

using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.appointments.appoitments
{
    public class AppointmentsGetAllModel : BaseApiResponse
    {
        public List<AppointmentsModel> model { get; set; }
    }
}

using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.appointments.appoitments
{
    public class AppointmentsGetByIdModel : BaseApiResponse
    {
        public AppointmentsModel model { get; set; }
    }
}

using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.appointments.appoitments
{
    public class AppoitmentsGetByIdModel : BaseApiResponse
    {
        public AppointmentsModel model { get; set; }
    }
}

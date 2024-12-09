using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Web.Models.ControllersModels.appointments.appoitments;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.Appointmets
{
    public interface IAppointmentsServiceApi : IBaseServiceApi<AppointmentsGetAllModel, AppointmentsGetByIdModel, AppointmentsSaveDto>
    {
    }
}

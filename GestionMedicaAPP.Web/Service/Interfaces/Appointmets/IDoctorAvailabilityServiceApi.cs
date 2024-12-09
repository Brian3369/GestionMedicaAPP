using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Web.Models.ControllersModels.appointments.DoctorAvailability;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.Appointmets
{
    public interface IDoctorAvailabilityServiceApi : IBaseServiceApi<DoctorAvailabilityGetAllModel, DoctorAvailabilityGetByIdModel, DoctorAvailabilitySaveDto>
    {
    }
}

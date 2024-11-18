using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Application.Response.Appointments.DoctorAvailability;

namespace GestionMedicaAPP.Application.Contracts.Appointments
{
    public interface IDoctorAvailabilityService : IBaseService<DoctorAvailabilityResponse, DoctorAvailabilitySaveDto, DoctorAvailabilityUpdateDto>
    {

    }
}

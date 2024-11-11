using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Application.Response.Appointments.Appointments;

namespace GestionMedicaAPP.Application.Contracts.Appointments
{
    public interface IDoctorAvailabilityService : IBaseService<UserResponse, AppointmentsSaveDto, AppointmentsUpdateDto>
    {

    }
}

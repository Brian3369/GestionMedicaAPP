using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Application.Dtos.Users.Patients;
using GestionMedicaAPP.Application.Response.System.Notifications;
using GestionMedicaAPP.Application.Response.Users.Patients;

namespace GestionMedicaAPP.Application.Contracts.Users
{
    public interface IPatientsService : IBaseService<PatientsResponse, PatientsSaveDto, PatientsUpdateDto>
    {
    }
}

using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Application.Dtos.Users.Doctors;
using GestionMedicaAPP.Application.Response.System.Notifications;
using GestionMedicaAPP.Application.Response.Users.Doctors;

namespace GestionMedicaAPP.Application.Contracts.Users
{
    public interface IDoctorsService : IBaseService<DoctorsResponse, DoctorsSaveDto, DoctorsUpdateDto>
    {
    }
}

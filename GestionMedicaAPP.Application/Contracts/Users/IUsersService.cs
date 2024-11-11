using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Application.Dtos.Users;
using GestionMedicaAPP.Application.Response.Appointments.Appointments;
using GestionMedicaAPP.Application.Response.Users;

namespace GestionMedicaAPP.Application.Contracts.Users
{
    public interface IUsersService : IBaseService<UsersResponse, UsersSaveDto, UsersUpdateDto>
    {

    }
}

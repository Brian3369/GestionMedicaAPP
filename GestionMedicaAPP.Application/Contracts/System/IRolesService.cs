using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Application.Dtos.System.Roles;
using GestionMedicaAPP.Application.Response.System.Notifications;
using GestionMedicaAPP.Application.Response.System.Roles;

namespace GestionMedicaAPP.Application.Contracts.System
{
    public interface IRolesService : IBaseService<RolesResponse, RolesSaveDto, RolesUpdateDto>
    {
    }
}

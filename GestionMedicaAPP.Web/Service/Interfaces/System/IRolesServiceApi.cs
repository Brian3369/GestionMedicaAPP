using GestionMedicaAPP.Application.Dtos.System.Roles;
using GestionMedicaAPP.Web.Models.ControllersModels.System.Roles;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.System
{
    public interface IRolesServiceApi : IBaseServiceApi<RolesGetAllModel, RolesGetByIdModel, RolesSaveDto>
    {
    }
}

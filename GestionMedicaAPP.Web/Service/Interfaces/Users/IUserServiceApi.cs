using GestionMedicaAPP.Application.Dtos.Users.users;
using GestionMedicaAPP.Web.Models.ControllersModels.Users.Users;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.Users
{
    public interface IUserServiceApi : IBaseServiceApi<UsersGetAllModel, UsersGetByIdModel, UsersSaveDto>
    {
    }
}

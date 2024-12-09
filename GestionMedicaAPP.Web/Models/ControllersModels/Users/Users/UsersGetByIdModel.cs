using GestionMedicaAPP.Persistance.Models.users;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Users.Users
{
    public class UsersGetByIdModel : BaseApiResponse
    {
        public UsersModel model { get; set; }

    }
}

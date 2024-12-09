using GestionMedicaAPP.Persistance.Models.users;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Users.Users
{
    public class UsersGetAllModel : BaseApiResponse
    {
        public List<UsersModel> model { get; set; }

    }
}

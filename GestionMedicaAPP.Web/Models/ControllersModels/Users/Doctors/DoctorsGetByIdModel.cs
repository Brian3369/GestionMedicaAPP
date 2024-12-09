using GestionMedicaAPP.Persistance.Models.users;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Users.Doctors
{
    public class DoctorsGetByIdModel : BaseApiResponse
    {
        public DoctorsModel model { get; set; }

    }
}

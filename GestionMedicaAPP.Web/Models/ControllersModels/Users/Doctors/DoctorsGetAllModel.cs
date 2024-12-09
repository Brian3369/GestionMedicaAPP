using GestionMedicaAPP.Persistance.Models.users;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Users.Doctors
{
    public class DoctorsGetAllModel : BaseApiResponse
    {
        public List<DoctorsModel> model { get; set; }

    }
}

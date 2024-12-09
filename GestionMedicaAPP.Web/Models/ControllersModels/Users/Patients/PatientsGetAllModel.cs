using GestionMedicaAPP.Persistance.Models.users;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Users.Patients
{
    public class PatientsGetAllModel : BaseApiResponse
    {
        public List<PatientsModel> model { get; set; }

    }
}

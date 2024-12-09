using GestionMedicaAPP.Persistance.Models.users;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Users.Patients
{
    public class PatientsGetByIdModel : BaseApiResponse
    {
        public PatientsModel model { get; set; }

    }
}

using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Persistance.Models.Medical;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Medical.Specialties
{
    public class SpecialtiesGetByIdModel : BaseApiResponse
    {
        public SpecialtiesModel model { get; set; }
    }
}

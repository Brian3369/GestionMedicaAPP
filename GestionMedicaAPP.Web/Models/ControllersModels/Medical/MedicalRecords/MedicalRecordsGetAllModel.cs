using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Persistance.Models.Medical;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Medical.MedicalRecords
{
    public class MedicalRecordsGetAllModel : BaseApiResponse
    {
        public List<MedicalRecordsModel> model { get; set; }
    }
}

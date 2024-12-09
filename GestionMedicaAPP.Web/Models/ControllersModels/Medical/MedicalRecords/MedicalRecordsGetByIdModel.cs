using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Persistance.Models.Medical;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.Medical.MedicalRecords
{
    public class MedicalRecordsGetByIdModel : BaseApiResponse
    {
        public MedicalRecordsModel model { get; set; }
    }
}

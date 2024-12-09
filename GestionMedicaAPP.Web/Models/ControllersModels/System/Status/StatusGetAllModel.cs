using GestionMedicaAPP.Persistance.Models.System;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.System.Status
{
    public class StatusGetAllModel : BaseApiResponse
    {
        public List<RolesModel> model { get; set; }
    }
}

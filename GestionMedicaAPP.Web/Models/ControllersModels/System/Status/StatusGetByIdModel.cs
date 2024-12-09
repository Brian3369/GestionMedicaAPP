using GestionMedicaAPP.Persistance.Models.System;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.System.Status
{
    public class StatusGetByIdModel : BaseApiResponse
    {
        public RolesModel model { get; set; }
    }
}

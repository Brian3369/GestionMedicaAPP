using GestionMedicaAPP.Persistance.Models.System;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.System.Roles
{
    public class RolesGetByIdModel : BaseApiResponse
    {
        public RolesModel model { get; set; }
    }
}

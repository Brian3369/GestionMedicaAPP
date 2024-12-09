using GestionMedicaAPP.Persistance.Models.System;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.System.Roles
{
    public class RolesGetAllModel : BaseApiResponse
    {
        public List<RolesModel> model { get; set; }
    }
}

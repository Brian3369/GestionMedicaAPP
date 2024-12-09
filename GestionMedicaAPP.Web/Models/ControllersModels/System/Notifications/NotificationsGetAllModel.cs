using GestionMedicaAPP.Persistance.Models.Medical;
using GestionMedicaAPP.Persistance.Models.System;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.System.Notifications
{
    public class NotificationsGetAllModel : BaseApiResponse
    {
        public List<NotificationsModel> model { get; set; }
    }
}

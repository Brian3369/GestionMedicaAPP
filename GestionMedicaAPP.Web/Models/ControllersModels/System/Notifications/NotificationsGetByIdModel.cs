using GestionMedicaAPP.Persistance.Models.System;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Models.ControllersModels.System.Notifications
{
    public class NotificationsGetByIdModel : BaseApiResponse
    {
        public NotificationsModel model { get; set; }
    }
}

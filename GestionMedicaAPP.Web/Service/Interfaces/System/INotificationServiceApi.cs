using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Web.Models.ControllersModels.System.Notifications;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.System
{
    public interface INotificationServiceApi : IBaseServiceApi<NotificationsGetAllModel, NotificationsGetByIdModel, NotificationsSaveDto, NotificationsUpdateDto>
    {
    }
}

using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Application.Response.Medical.AvailabilityModes;
using GestionMedicaAPP.Application.Response.System.Notifications;

namespace GestionMedicaAPP.Application.Contracts.System
{
    public interface INotificationsService : IBaseService<NotificationsResponse, NotificationsSaveDto, NotificationsUpdateDto>
    {
    }
}

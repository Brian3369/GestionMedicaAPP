using GestionMedicaAPP.Infraestructure.Models;
using GestionMedicaAPP.Infraestructure.Result;

namespace GestionMedicaAPP.Infraestructure.Interfaces
{
    public interface IPushService
    {
        Task<NotificationResult> SendPushNotification(PushModel pushModel);

    }
}

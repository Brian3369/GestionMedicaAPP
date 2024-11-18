using GestionMedicaAPP.Infraestructure.Interfaces;
using GestionMedicaAPP.Infraestructure.Models;
using GestionMedicaAPP.Infraestructure.Result;

namespace GestionMedicaAPP.Infraestructure.Services
{
    public class PushNotificationService : IPushService
    {
        public Task<NotificationResult> SendPushNotification(PushModel pushModel)
        {
            throw new NotImplementedException();
        }
    }
}


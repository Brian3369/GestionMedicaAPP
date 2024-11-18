using GestionMedicaAPP.Infraestructure.Models;
using GestionMedicaAPP.Infraestructure.Result;

namespace GestionMedicaAPP.Infraestructure.Interfaces
{
    public interface ISmsService
    {
        Task<NotificationResult> SendSmsAsync(SmsModel smsModel);
    }
}

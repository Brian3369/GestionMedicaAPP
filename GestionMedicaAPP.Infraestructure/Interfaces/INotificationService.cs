using GestionMedicaAPP.Infraestructure.Models;
using GestionMedicaAPP.Infraestructure.Result;

namespace GestionMedicaAPP.Infraestructure.Interfaces
{
    public interface INotificacionService<TEntity> where TEntity : class
    {
        Task<NotificationResult> SendEmailAsync(EmailModel emailModel);
        Task<NotificationResult> SendSmsAsync(SmsModel smsModel);
        Task<NotificationResult> SendPushNotification(TEntity pushModel);
    }
}
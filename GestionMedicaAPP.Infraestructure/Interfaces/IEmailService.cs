using GestionMedicaAPP.Infraestructure.Models;
using GestionMedicaAPP.Infraestructure.Result;

namespace GestionMedicaAPP.Infraestructure.Interfaces
{
    public interface IEmailService
    {
        Task<NotificationResult> SendEmailAsync(EmailModel emailModel);
    }
}

using GestionMedicaAPP.Infraestructure.Interfaces;
using GestionMedicaAPP.Infraestructure.Models;
using GestionMedicaAPP.Infraestructure.Result;
using Newtonsoft.Json;
using System.Text;

namespace GestionMedicaAPP.Infraestructure.Services
{
    public class SmsService : ISmsService
    {

        public async Task<NotificationResult> SendSmsAsync(SmsModel smsModel)
        {
            NotificationResult result = new NotificationResult();
            try
            {
                var httpClient = new HttpClient();

                var contect = new StringContent(JsonConvert.SerializeObject(smsModel), Encoding.UTF8, "application/json");

                await httpClient.PostAsync("miurl", contect);
            }
            catch (Exception ex)
            {

                result.Message = $"Error realizando la notificación {ex.Message}";

            }
            return result;
        }
    }
}

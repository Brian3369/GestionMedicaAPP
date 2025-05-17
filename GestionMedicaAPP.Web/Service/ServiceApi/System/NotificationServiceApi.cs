using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.System.Notifications;
using GestionMedicaAPP.Web.Service.Interfaces.System;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.System
{
    public class NotificationServiceApi : INotificationServiceApi
    {
        private readonly HttpClient _httpClient;

        public NotificationServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/Notifications/");
        }

        public async Task<NotificationsGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetNotifications");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NotificationsGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<NotificationsGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetNotificationById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NotificationsGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(NotificationsSaveDto notification)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveNotification", notification);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(NotificationsUpdateDto notification)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateNotification", notification);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteNotification/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

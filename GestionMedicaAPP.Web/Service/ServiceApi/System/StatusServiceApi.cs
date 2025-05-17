using GestionMedicaAPP.Application.Dtos.System.Status;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.System.Status;
using GestionMedicaAPP.Web.Service.Interfaces.System;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.System
{
    public class StatusServiceApi : IStatusServiceApi
    {
        private readonly HttpClient _httpClient;

        public StatusServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/Status/");
        }

        public async Task<StatusGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetStatuses");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StatusGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<StatusGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetStatusById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StatusGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(StatusSaveDto status)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveStatus", status);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(StatusUpdateDto status)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateStatus", status);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteStatus/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

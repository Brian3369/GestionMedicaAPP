using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.Medical.AvailabilityMode;
using GestionMedicaAPP.Web.Models.ControllersModels.Medical.AvailabilityModes;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.Base.Medical
{
    public class AvailabilityModeServiceApi
    {
        private readonly HttpClient _httpClient;

        public AvailabilityModeServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/AvailabilityModes/");
        }

        public async Task<AvailabilityModeGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetAvailabilityModes");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AvailabilityModeGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<AvailabilityModeGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetAvailabilityModeById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AvailabilityModeGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(AvailabilityModesSaveDto availabilityMode)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveAvailabilityMode", availabilityMode);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(AvailabilityModesSaveDto availabilityMode)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateAvailabilityMode", availabilityMode);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteAvailabilityMode/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

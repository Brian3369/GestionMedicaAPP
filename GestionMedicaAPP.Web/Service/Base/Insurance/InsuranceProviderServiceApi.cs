using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.Insurance.InsuranceProviders;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.Base.Insurance
{
    public class InsuranceProviderServiceApi
    {
        private readonly HttpClient _httpClient;

        public InsuranceProviderServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/InsuranceProviders/");
        }

        public async Task<InsuranceProviderGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetInsuranceProviders");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<InsuranceProviderGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<InsuranceProviderGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetInsuranceProviderById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<InsuranceProviderGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(InsuranceProviderSaveDto insuranceProvider)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveInsuranceProvider", insuranceProvider);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(int id, InsuranceProviderSaveDto insuranceProvider)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateInsuranceProvider/{id}", insuranceProvider);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteInsuranceProvider/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

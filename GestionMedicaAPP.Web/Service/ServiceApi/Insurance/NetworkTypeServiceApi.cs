using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.Insurance.NetworkType;
using GestionMedicaAPP.Web.Service.Interfaces.Insurance;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Insurance
{
    public class NetworkTypeServiceApi : INetworkTypeServiceApi
    {
        private readonly HttpClient _httpClient;

        public NetworkTypeServiceApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiConecction:ApiBaseInsuranceProviders"]);
        }

        public async Task<NetworkTypeGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("NetworkType/GetNetworkType");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NetworkTypeGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<NetworkTypeGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetNetworkTypeById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NetworkTypeGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(NetworkTypeSaveDto networkType)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveNetworkType", networkType);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(NetworkTypeUpdateDto networkType)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateNetworkType", networkType);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteNetworkType/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

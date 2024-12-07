using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Web.Models.Base;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.Repository.Insurance.NetworkType
{
    public class NetworkTypeApiRepository : INetworkTypeApiRepository
    {
        private readonly HttpClient _httpClient;

        public NetworkTypeApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/NetworkTypes/");
        }

        public async Task<IEnumerable<NetworkTypeBaseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetNetworkTypes");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IEnumerable<NetworkTypeBaseDto>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<NetworkTypeBaseDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetNetworkTypeById?id={id}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<NetworkTypeBaseDto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> CreateAsync(NetworkTypeSaveDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveNetworkType", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> UpdateAsync(int id, NetworkTypeSaveDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateNetworkType?id={id}", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteNetworkType?id={id}");
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}

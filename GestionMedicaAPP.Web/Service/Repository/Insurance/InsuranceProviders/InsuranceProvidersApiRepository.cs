using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using GestionMedicaAPP.Web.Models.Base;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.Repository.Insurance.InsuranceProviders
{
    public class InsuranceProvidersRepository : IInsuranceProvidersApiRepository
    {
        private readonly HttpClient _httpClient;

        public InsuranceProvidersRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/InsuranceProviders/");
        }

        public async Task<IEnumerable<InsuranceProviderBaseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetInsuranceProviders");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IEnumerable<InsuranceProviderBaseDto>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<InsuranceProviderBaseDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetInsuranceProviderById?id={id}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<InsuranceProviderBaseDto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> CreateAsync(InsuranceProviderSaveDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveInsuranceProvider", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> UpdateAsync(int id, InsuranceProviderSaveDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateInsuranceProvider?id={id}", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteInsuranceProvider?id={id}");
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}

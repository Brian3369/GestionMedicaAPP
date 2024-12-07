using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Web.Models.Base;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.Repository.Medical.AvailabilityModes
{
    public class AvailabilityModesApiRepository : IAvailabilityModesApiRepository
    {
        private readonly HttpClient _httpClient;

        public AvailabilityModesApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/AvailabilityModes/");
        }

        public async Task<IEnumerable<AvailabilityModesBaseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetAvailabilityModes");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IEnumerable<AvailabilityModesBaseDto>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<AvailabilityModesBaseDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetAvailabilityModeById?id={id}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<AvailabilityModesBaseDto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> CreateAsync(AvailabilityModesSaveDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveAvailabilityMode", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> UpdateAsync(int id, AvailabilityModesSaveDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateAvailabilityMode?id={id}", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteAvailabilityMode?id={id}");
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}

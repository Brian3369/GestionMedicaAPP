using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using GestionMedicaAPP.Web.Models.Base;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.Repository.Appointments.DoctorAvailability
{
    public class DoctorAvailabilityApiRepository : IDoctorAvailabilityApiRepository
    {
        private readonly HttpClient _httpClient;

        public DoctorAvailabilityApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/DoctorAvailability/");
        }

        public async Task<IEnumerable<DoctorAvailabilityBaseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetDoctorAvailability");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IEnumerable<DoctorAvailabilityBaseDto>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<DoctorAvailabilityBaseDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetDoctorAvailabilityById?id={id}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<DoctorAvailabilityBaseDto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> CreateAsync(DoctorAvailabilitySaveDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveDoctorAvailability", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> UpdateAsync(int id, DoctorAvailabilitySaveDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateDoctorAvailability?id={id}", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteDoctorAvailability?id={id}");
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}

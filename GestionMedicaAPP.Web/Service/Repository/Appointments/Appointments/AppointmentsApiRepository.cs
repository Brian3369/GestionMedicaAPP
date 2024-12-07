using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using GestionMedicaAPP.Web.Models.Base;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.Repository.Appointments.Appointments
{
    public class AppointmentsRepository : IAppointmentsApiRepository
    {
        private readonly HttpClient _httpClient;

        public AppointmentsRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/Appointments/");
        }

        public async Task<IEnumerable<AppointmentsBaseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetAppointments");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IEnumerable<AppointmentsBaseDto>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<AppointmentsBaseDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetAppointmentById?id={id}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<AppointmentsBaseDto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> CreateAsync(AppointmentsSaveDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveAppointment", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> UpdateAsync(int id, AppointmentsSaveDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateAppointment?id={id}", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteAppointment?id={id}");
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}

using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.appointments.appoitments;
using GestionMedicaAPP.Web.Service.Interfaces.Appointmets;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Appointmets
{
    public class AppointmentServiceApi : IAppointmentsServiceApi
    {
        private readonly HttpClient _httpClient;

        public AppointmentServiceApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiConecction:ApiBaseAppointments"]);
        }

        public async Task<AppointmentsGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Appointments/GetAppointments");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AppointmentsGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<AppointmentsGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Appointments/GetAppointmentsById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AppointmentsGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(AppointmentsSaveDto appointment)
        {
            var response = await _httpClient.PostAsJsonAsync("Appointments/SaveAppointments", appointment);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(AppointmentsUpdateDto appointment)
        {
            var response = await _httpClient.PutAsJsonAsync($"Appointments/UpdateAppointments", appointment);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Appointments/RemoveAppointments?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

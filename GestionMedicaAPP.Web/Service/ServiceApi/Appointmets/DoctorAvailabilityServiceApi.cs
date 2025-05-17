using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.appointments.DoctorAvailability;
using GestionMedicaAPP.Web.Service.Interfaces.Appointmets;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Appointmets
{
    public class DoctorAvailabilityServiceApi : IDoctorAvailabilityServiceApi
    {
        private readonly HttpClient _httpClient;

        public DoctorAvailabilityServiceApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiConecction:ApiBaseAppointments"]);
        }

        public async Task<DoctorAvailabilityGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("DoctorAvailability/GetDoctorAvailability");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DoctorAvailabilityGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<DoctorAvailabilityGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetDoctorAvailabilityById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DoctorAvailabilityGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(DoctorAvailabilitySaveDto doctorAvailability)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveDoctorAvailability", doctorAvailability);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(DoctorAvailabilitySaveDto doctorAvailability)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateDoctorAvailability", doctorAvailability);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"RemoveDoctorAvailability?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

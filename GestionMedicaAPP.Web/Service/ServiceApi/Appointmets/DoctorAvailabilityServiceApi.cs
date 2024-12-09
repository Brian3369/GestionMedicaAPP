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

        public DoctorAvailabilityServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/DoctorAvailability/");
        }

        // Obtener todas las disponibilidades de los doctores
        public async Task<DoctorAvailabilityGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetDoctorAvailability");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DoctorAvailabilityGetAllModel>(responseString);
            }
            return null;
        }

        // Obtener la disponibilidad de un doctor por ID
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

        // Crear una nueva disponibilidad para un doctor
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

        // Actualizar la disponibilidad de un doctor por ID
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

        // Eliminar la disponibilidad de un doctor por ID
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

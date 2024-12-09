using GestionMedicaAPP.Application.Dtos.Users.Patients;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.Users.Patients;
using GestionMedicaAPP.Web.Service.Interfaces.Users;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Users
{
    public class PatientServiceApi : IPatientServiceApi
    {
        private readonly HttpClient _httpClient;

        public PatientServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/Patients/");
        }

        public async Task<PatientsGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetPatients");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PatientsGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<PatientsGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetPatientById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PatientsGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(PatientsSaveDto patient)
        {
            var response = await _httpClient.PostAsJsonAsync("SavePatient", patient);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(PatientsSaveDto patient)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdatePatient", patient);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeletePatient/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

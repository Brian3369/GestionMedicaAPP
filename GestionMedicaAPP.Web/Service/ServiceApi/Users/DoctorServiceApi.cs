using GestionMedicaAPP.Application.Dtos.Users.Doctors;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.Users.Doctors;
using GestionMedicaAPP.Web.Service.Interfaces.Users;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Users
{
    public class DoctorServiceApi : IDoctorServiceApi
    {
        
        private readonly HttpClient _httpClient;

        public DoctorServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/Doctors/");
        }

        public async Task<DoctorsGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetDoctors");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DoctorsGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<DoctorsGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetDoctorById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DoctorsGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(DoctorsSaveDto doctor)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveDoctor", doctor);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(DoctorsSaveDto doctor)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateDoctor", doctor);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteDoctor/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

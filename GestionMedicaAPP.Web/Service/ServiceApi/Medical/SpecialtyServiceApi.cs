using GestionMedicaAPP.Application.Dtos.Medical.Specialties;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.Medical.Specialties;
using GestionMedicaAPP.Web.Service.Interfaces.Medical;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Medical
{
    public class SpecialtiesServiceApi : ISpecialtiesServiceApi
    {
        private readonly HttpClient _httpClient;

        public SpecialtiesServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/Specialties/");
        }

        public async Task<SpecialtiesGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetSpecialties");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SpecialtiesGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<SpecialtiesGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetSpecialtyById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SpecialtiesGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(SpecialtiesSaveDto specialty)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveSpecialty", specialty);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(SpecialtiesUpdateDto specialty)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateSpecialty", specialty);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteSpecialty/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

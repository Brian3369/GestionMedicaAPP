using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.Medical.MedicalRecords;
using GestionMedicaAPP.Web.Service.Interfaces.Medical;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Medical
{
    public class MedicalRecordServiceApi : IMedicalRecordServiceApi
    {
        private readonly HttpClient _httpClient;

        public MedicalRecordServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/MedicalRecords/");
        }

        public async Task<MedicalRecordsGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetMedicalRecords");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MedicalRecordsGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<MedicalRecordsGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetMedicalRecordById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MedicalRecordsGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(MedicalRecordsSaveDto medicalRecord)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveMedicalRecord", medicalRecord);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(MedicalRecordsUpdateDto medicalRecord)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateMedicalRecord/", medicalRecord);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteMedicalRecord/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

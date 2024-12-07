using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Web.Models.Base;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.Repository.Medical.MedicalRecords
{
    public class MedicalRecordsRepository : IMedicalRecordsApiRepository
    {
        private readonly HttpClient _httpClient;

        public MedicalRecordsRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/MedicalRecords/");
        }

        public async Task<IEnumerable<MedicalRecordsBaseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetMedicalRecords");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IEnumerable<MedicalRecordsBaseDto>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<MedicalRecordsBaseDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetMedicalRecordById?id={id}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<MedicalRecordsBaseDto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> CreateAsync(MedicalRecordsSaveDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveMedicalRecord", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> UpdateAsync(int id, MedicalRecordsSaveDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateMedicalRecord?id={id}", dto);
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteMedicalRecord?id={id}");
            return JsonConvert.DeserializeObject<BaseApiResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}

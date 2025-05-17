using GestionMedicaAPP.Application.Dtos.System.Roles;
using GestionMedicaAPP.Web.Controllers.System.Adm;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.System.Roles;
using GestionMedicaAPP.Web.Service.Interfaces.System;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.System
{
    public class RoleServiceApi : IRolesServiceApi
    {
        private readonly HttpClient _httpClient;

        public RoleServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/Roles/");
        }

        public async Task<RolesGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetRoles");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RolesGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<RolesGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetRoleById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RolesGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(RolesSaveDto role)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveRole", role);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(RolesUpdateDto role)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateRole", role);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteRole/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

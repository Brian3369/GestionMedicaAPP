using GestionMedicaAPP.Application.Dtos.Users.users;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.Users.Users;
using GestionMedicaAPP.Web.Service.Interfaces.Users;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Users
{
    public class UserServiceApi : IUserServiceApi
    {
        private readonly HttpClient _httpClient;

        public UserServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5184/Users/");
        }

        public async Task<UsersGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("GetUsers");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UsersGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<UsersGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetUserById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UsersGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(UsersSaveDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveUser", user);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(UsersUpdateDto user)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateUser", user);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteUser/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

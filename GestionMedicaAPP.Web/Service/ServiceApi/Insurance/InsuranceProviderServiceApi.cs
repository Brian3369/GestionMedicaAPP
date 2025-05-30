﻿using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.Insurance.InsuranceProviders;
using GestionMedicaAPP.Web.Service.Interfaces.Insurance;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Insurance
{
    public class InsuranceProviderServiceApi : IInsuranceProvidersServiceApi
    {
        private readonly HttpClient _httpClient;

        public InsuranceProviderServiceApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiConecction:ApiBaseInsuranceProviders"]);
        }

        public async Task<InsuranceProviderGetAllModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("InsuranceProviders/GetInsuranceProviders");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<InsuranceProviderGetAllModel>(responseString);
            }
            return null;
        }

        public async Task<InsuranceProviderGetByIdModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"GetInsuranceProviderById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<InsuranceProviderGetByIdModel>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> CreateAsync(InsuranceProviderSaveDto insuranceProvider)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveInsuranceProvider", insuranceProvider);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> UpdateAsync(InsuranceProviderUpdateDto insuranceProvider)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateInsuranceProvider", insuranceProvider);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteInsuranceProvider/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseApiResponse>(responseString);
            }
            return null;
        }
    }
}

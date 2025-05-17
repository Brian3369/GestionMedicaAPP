using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Models.ControllersModels.appointments.appoitments;
using GestionMedicaAPP.Web.Service.Interfaces.Appointmets;

namespace GestionMedicaAPP.Web.Service.ServiceApi.Appointmets
{
    public class AppointmentServiceApi : IAppointmentsServiceApi
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AppointmentServiceApi> _logger;

        public AppointmentServiceApi(HttpClient httpClient,ILogger<AppointmentServiceApi> logger, IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiConecction:ApiBaseAppointments"]);
        }

        public async Task<AppointmentsGetAllModel> GetAllAsync()
        {
            AppointmentsGetAllModel appointmentsGetAllModel = new AppointmentsGetAllModel();
            try
            {
                var response = await _httpClient.GetAsync("Appointments/GetAppointments");

                response.EnsureSuccessStatusCode();
                appointmentsGetAllModel.message = "Citas encontradas";
                appointmentsGetAllModel = await response.Content.ReadFromJsonAsync<AppointmentsGetAllModel>();
            }
            catch (Exception ex)
            {
                appointmentsGetAllModel.isSuccess = false;
                appointmentsGetAllModel.message = "Error obteniendo las citas";
                _logger.LogError($"{appointmentsGetAllModel.message} {ex.ToString()}");
            }
            return appointmentsGetAllModel;
        }

        public async Task<AppointmentsGetByIdModel> GetByIdAsync(int id)
        {
            AppointmentsGetByIdModel appointmentsGetByIdModel = new AppointmentsGetByIdModel();
            try
            {
                var response = await _httpClient.GetAsync($"Appointments/GetAppointmentsById?id={id}");
                response.EnsureSuccessStatusCode();
                appointmentsGetByIdModel.message = "Cita encontrada";
                appointmentsGetByIdModel = await response.Content.ReadFromJsonAsync<AppointmentsGetByIdModel>();
            }
            catch (Exception ex)
            {
                appointmentsGetByIdModel.isSuccess = false;
                appointmentsGetByIdModel.message = "Error obteniendo la cita";
                _logger.LogError($"{appointmentsGetByIdModel.message} {ex.ToString()}");
            }
            return appointmentsGetByIdModel;
        }

        public async Task<BaseApiResponse> CreateAsync(AppointmentsSaveDto appointment)
        {
            BaseApiResponse apiResponse = new BaseApiResponse();
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Appointments/SaveAppointments", appointment);
                response.EnsureSuccessStatusCode();
                apiResponse.message = "Cita guardada";
            }
            catch (Exception ex)
            {
                apiResponse.message = "Error al guardar cita";
                _logger.LogError($"{apiResponse.message} {ex.ToString()}");
            }
            return apiResponse;
        }

        public async Task<BaseApiResponse> UpdateAsync(AppointmentsUpdateDto appointment)
        {
            BaseApiResponse apiResponse = new BaseApiResponse();
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"Appointments/UpdateAppointments", appointment);
                response.EnsureSuccessStatusCode();
                apiResponse.message = "Cita actualizada correctamente";
            }
            catch (Exception ex)
            {
                apiResponse.message = "Error al actualizar cita";
                _logger.LogError($"{apiResponse.message} {ex.ToString()}");
            }
            return apiResponse;
        }

        public async Task<BaseApiResponse> DeleteAsync(int id)
        {
            BaseApiResponse apiResponse = new BaseApiResponse();
            try
            {
                var response = await _httpClient.DeleteAsync($"Appointments/RemoveAppointments?id={id}");
                response.EnsureSuccessStatusCode();
                apiResponse.message = "Cita eliminada correctamente";
            }
            catch (Exception ex)
            {
                apiResponse.message = "Error al eliminar cita";
                _logger.LogError($"{apiResponse.message} {ex.ToString()}");
            }
            return apiResponse;
        }
    }
}

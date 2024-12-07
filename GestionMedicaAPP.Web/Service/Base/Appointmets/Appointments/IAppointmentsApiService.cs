using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Base.Appointmets.Appointments
{
    public interface IAppointmentsApiService
    {
        Task<IEnumerable<AppointmentsBaseDto>> GetAllAsync();
        Task<AppointmentsBaseDto> GetByIdAsync(int id);
        Task<BaseApiResponse> CreateAsync(AppointmentsSaveDto dto);
        Task<BaseApiResponse> UpdateAsync(int id, AppointmentsSaveDto dto);
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}

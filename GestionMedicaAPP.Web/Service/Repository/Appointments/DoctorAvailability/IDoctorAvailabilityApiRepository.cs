using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Repository.Appointments.DoctorAvailability
{
    public interface IDoctorAvailabilityApiRepository
    {
        Task<IEnumerable<DoctorAvailabilityBaseDto>> GetAllAsync();
        Task<DoctorAvailabilityBaseDto> GetByIdAsync(int id);
        Task<BaseApiResponse> CreateAsync(DoctorAvailabilitySaveDto dto);
        Task<BaseApiResponse> UpdateAsync(int id, DoctorAvailabilitySaveDto dto);
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}

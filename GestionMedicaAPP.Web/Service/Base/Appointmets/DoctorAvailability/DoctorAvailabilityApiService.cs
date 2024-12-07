using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Service.Repository.Appointments.DoctorAvailability;

namespace GestionMedicaAPP.Web.Service.Base.Appointmets.DoctorAvailability
{
    public class DoctorAvailabilityApiService : IDoctorAvailabilityApiService
    {
        private readonly IDoctorAvailabilityApiRepository _repository;

        public DoctorAvailabilityApiService(IDoctorAvailabilityApiRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<DoctorAvailabilityBaseDto>> GetAllAsync() => _repository.GetAllAsync();

        public Task<DoctorAvailabilityBaseDto> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<BaseApiResponse> CreateAsync(DoctorAvailabilitySaveDto dto) => _repository.CreateAsync(dto);

        public Task<BaseApiResponse> UpdateAsync(int id, DoctorAvailabilitySaveDto dto) => _repository.UpdateAsync(id, dto);

        public Task<BaseApiResponse> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

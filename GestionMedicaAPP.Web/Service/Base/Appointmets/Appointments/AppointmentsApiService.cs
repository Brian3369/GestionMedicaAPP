using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Service.Repository.Appointments.Appointments;

namespace GestionMedicaAPP.Web.Service.Base.Appointmets.Appointments
{
    public class AppointmentsApiService : IAppointmentsApiService
    {
        private readonly IAppointmentsApiRepository _repository;

        public AppointmentsApiService(IAppointmentsApiRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<AppointmentsBaseDto>> GetAllAsync() => _repository.GetAllAsync();

        public Task<AppointmentsBaseDto> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<BaseApiResponse> CreateAsync(AppointmentsSaveDto dto) => _repository.CreateAsync(dto);

        public Task<BaseApiResponse> UpdateAsync(int id, AppointmentsSaveDto dto) => _repository.UpdateAsync(id, dto);

        public Task<BaseApiResponse> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

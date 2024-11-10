using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Application.Response.Appointments.Appointments;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using GestionMedicaAPP.Persistance.Repositories.appointments;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.appointments
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
        private readonly ILogger<DoctorAvailabilityService> _logger;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository doctorAvailabilityRepository, ILogger<DoctorAvailabilityService> logger)
        {
            if (doctorAvailabilityRepository is null)
            {
                throw new ArgumentNullException(nameof(doctorAvailabilityRepository));
            }
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
        }
        public Task<AppointmentsResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentsResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentsResponse> SaveAsync(AppointmentsSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentsResponse> UpdateAsync(AppointmentsUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

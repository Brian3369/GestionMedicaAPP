using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users.Patients;
using GestionMedicaAPP.Application.Response.Users.Patients;
using GestionMedicaAPP.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.users
{
    public class PatientsService : IPatientsService
    {
        private readonly IPatientsRepository _PatientsRepository;
        private readonly ILogger<PatientsService> _logger;
        public PatientsService(IPatientsRepository PatientsRepository, ILogger<PatientsService> logger)
        {
            _logger = logger;
            _PatientsRepository = PatientsRepository;
        }
        public Task<PatientsResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PatientsResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PatientsResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PatientsResponse> SaveAsync(PatientsSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<PatientsResponse> UpdateAsync(PatientsUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

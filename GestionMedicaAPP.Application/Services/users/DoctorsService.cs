using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users.Doctors;
using GestionMedicaAPP.Application.Response.Users.Doctors;
using GestionMedicaAPP.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.users
{
    public class DoctorsService : IDoctorsService
    {
        private readonly IDoctorsRepository _DoctorsRepository;
        private readonly ILogger<DoctorsService> _logger;
        public DoctorsService(IDoctorsRepository DoctorsRepository, ILogger<DoctorsService> logger)
        {
            _logger = logger;
            _DoctorsRepository = DoctorsRepository;
        }
        public Task<DoctorsResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DoctorsResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorsResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorsResponse> SaveAsync(DoctorsSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorsResponse> UpdateAsync(DoctorsUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

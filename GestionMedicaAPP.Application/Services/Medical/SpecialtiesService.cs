using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.Specialties;
using GestionMedicaAPP.Application.Response.Medical.Specialties;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.Medical
{
    public class SpecialtiesService : ISpecialtiesService
    {
        private readonly ISpecialtiesRepository _SpecialtiesRepository;
        private readonly ILogger<SpecialtiesService> _logger;
        public SpecialtiesService(ISpecialtiesRepository SpecialtiesRepository, ILogger<SpecialtiesService> logger)
        {
            _logger = logger;
            _SpecialtiesRepository = SpecialtiesRepository;
        }
        public Task<SpecialtiesResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SpecialtiesResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SpecialtiesResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SpecialtiesResponse> SaveAsync(SpecialtiesSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<SpecialtiesResponse> UpdateAsync(SpecialtiesUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

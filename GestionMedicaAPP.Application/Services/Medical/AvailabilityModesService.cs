using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Application.Response.Medical.AvailabilityModes;
using GestionMedicaAPP.Application.Services.Insurance;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.Medical
{
    public class AvailabilityModesService : IAvailabilityModesService
    {
        private readonly IAvailabilityModesRepository _AvailabilityModesRepository;
        private readonly ILogger<AvailabilityModesService> _logger;
        public AvailabilityModesService(IAvailabilityModesRepository AvailabilityModessRepository, ILogger<AvailabilityModesService> logger)
        {
            _logger = logger;
            _AvailabilityModesRepository = AvailabilityModessRepository;
        }
        public Task<AvailabilityModesResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityModesResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityModesResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityModesResponse> SaveAsync(AvailabilityModesSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityModesResponse> UpdateAsync(AvailabilityModesUpdate dto)
        {
            throw new NotImplementedException();
        }
    }
}

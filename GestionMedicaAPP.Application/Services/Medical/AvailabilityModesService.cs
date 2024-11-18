using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Application.Response.Medical.AvailabilityModes;
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
        public async Task<AvailabilityModesResponse> GetAll()
        {
            AvailabilityModesResponse AvailabilityModessResponse = new AvailabilityModesResponse();

            try
            {
                var result = await _AvailabilityModesRepository.GetAll();

                if (!result.Success)
                {
                    AvailabilityModessResponse.Message = result.Message;
                    AvailabilityModessResponse.IsSuccess = result.Success;
                    return AvailabilityModessResponse;
                }

                AvailabilityModessResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                AvailabilityModessResponse.IsSuccess = false;
                AvailabilityModessResponse.Model = "Error obteniendo tipos de conexion";
                _logger.LogError(AvailabilityModessResponse.Message, ex.ToString());
            }

            return AvailabilityModessResponse;
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

        public Task<AvailabilityModesResponse> UpdateAsync(AvailabilityModesUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

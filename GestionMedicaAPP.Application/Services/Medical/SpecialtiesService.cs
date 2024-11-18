using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.Specialties;
using GestionMedicaAPP.Application.Response.Medical.Specialties;
using GestionMedicaAPP.Application.Response.Medical.Specialties;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Persistance.Repositories.Medical;
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
        public async Task<SpecialtiesResponse> GetAll()
        {
            SpecialtiesResponse SpecialtiessResponse = new SpecialtiesResponse();

            try
            {
                var result = await _SpecialtiesRepository.GetAll();

                if (!result.Success)
                {
                    SpecialtiessResponse.Message = result.Message;
                    SpecialtiessResponse.IsSuccess = result.Success;
                    return SpecialtiessResponse;
                }

                SpecialtiessResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                SpecialtiessResponse.IsSuccess = false;
                SpecialtiessResponse.Model = "Error obteniendo las especialidades";
                _logger.LogError(SpecialtiessResponse.Message, ex.ToString());
            }

            return SpecialtiessResponse;
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

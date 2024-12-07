using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Base.Medical.AvailabilityModes
{
    public class AvailabilityModesApiService : IAvailabilityModesApiService
    {
        private readonly IAvailabilityModesApiRepository _repository;

        public AvailabilityModesApiService(IAvailabilityModesApiRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<AvailabilityModesBaseDto>> GetAllAsync() => _repository.GetAllAsync();

        public Task<AvailabilityModesBaseDto> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<BaseApiResponse> CreateAsync(AvailabilityModesSaveDto dto) => _repository.CreateAsync(dto);

        public Task<BaseApiResponse> UpdateAsync(int id, AvailabilityModesSaveDto dto) => _repository.UpdateAsync(id, dto);

        public Task<BaseApiResponse> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

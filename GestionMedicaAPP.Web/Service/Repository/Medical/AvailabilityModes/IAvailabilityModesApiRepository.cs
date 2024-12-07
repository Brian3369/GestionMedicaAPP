using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Repository.Medical.AvailabilityModes
{
    public interface IAvailabilityModesApiRepository
    {
        Task<IEnumerable<AvailabilityModesBaseDto>> GetAllAsync();
        Task<AvailabilityModesBaseDto> GetByIdAsync(int id);
        Task<BaseApiResponse> CreateAsync(AvailabilityModesSaveDto dto);
        Task<BaseApiResponse> UpdateAsync(int id, AvailabilityModesSaveDto dto);
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}

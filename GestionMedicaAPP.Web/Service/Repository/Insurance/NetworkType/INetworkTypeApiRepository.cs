using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Repository.Insurance.NetworkType
{
    public interface INetworkTypeApiRepository
    {
        Task<IEnumerable<NetworkTypeBaseDto>> GetAllAsync();
        Task<NetworkTypeBaseDto> GetByIdAsync(int id);
        Task<BaseApiResponse> CreateAsync(NetworkTypeSaveDto dto);
        Task<BaseApiResponse> UpdateAsync(int id, NetworkTypeSaveDto dto);
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}

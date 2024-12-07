using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Base.Insurance.NetworkType
{
    public interface INetworkTypeApiService
    {
        Task<IEnumerable<NetworkTypeBaseDto>> GetAllAsync();
        Task<NetworkTypeBaseDto> GetByIdAsync(int id);
        Task<BaseApiResponse> CreateAsync(NetworkTypeSaveDto dto);
        Task<BaseApiResponse> UpdateAsync(int id, NetworkTypeSaveDto dto);
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}

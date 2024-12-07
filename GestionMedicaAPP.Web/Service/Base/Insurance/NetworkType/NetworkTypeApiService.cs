using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Base.Insurance.NetworkType
{
    public class NetworkTypeApiService : INetworkTypeApiService
    {
        private readonly INetworkTypeApiRepository _repository;

        public NetworkTypeService(INetworkTypeApiRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<NetworkTypeBaseDto>> GetAllAsync() => _repository.GetAllAsync();

        public Task<NetworkTypeBaseDto> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<BaseApiResponse> CreateAsync(NetworkTypeSaveDto dto) => _repository.CreateAsync(dto);

        public Task<BaseApiResponse> UpdateAsync(int id, NetworkTypeSaveDto dto) => _repository.UpdateAsync(id, dto);

        public Task<BaseApiResponse> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

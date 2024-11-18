using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Application.Response.Insurance.NetworkType;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.Insurance
{
    public class NetworkTypeService : INetworkTypeService
    {
        private readonly INetworkTypeRepository _NetworkTypeRepository;
        private readonly ILogger<NetworkTypeService> _logger;
        public NetworkTypeService(INetworkTypeRepository NetworkTypesRepository, ILogger<NetworkTypeService> logger)
        {
            _logger = logger;
            _NetworkTypeRepository = NetworkTypesRepository;
        }
        public Task<NetworkTypeResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<NetworkTypeResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<NetworkTypeResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<NetworkTypeResponse> SaveAsync(NetworkTypeSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<NetworkTypeResponse> UpdateAsync(NetworkTypeUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Application.Response.Insurance.NetworkType;
using GestionMedicaAPP.Application.Response.Insurance.NetworkType;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using GestionMedicaAPP.Persistance.Repositories.Insurance;
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
        public async Task<NetworkTypeResponse> GetAll()
        {
            NetworkTypeResponse NetworkTypesResponse = new NetworkTypeResponse();

            try
            {
                var result = await _NetworkTypeRepository.GetAll();

                if (!result.Success)
                {
                    NetworkTypesResponse.Message = result.Message;
                    NetworkTypesResponse.IsSuccess = result.Success;
                    return NetworkTypesResponse;
                }

                NetworkTypesResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                NetworkTypesResponse.IsSuccess = false;
                NetworkTypesResponse.Model = "Error obteniendo tipos de conexion";
                _logger.LogError(NetworkTypesResponse.Message, ex.ToString());
            }

            return NetworkTypesResponse;
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

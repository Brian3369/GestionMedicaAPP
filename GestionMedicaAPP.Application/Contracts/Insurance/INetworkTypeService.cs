using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Application.Response.Insurance.NetworkType;

namespace GestionMedicaAPP.Application.Contracts.Insurance
{
    public interface INetworkTypeService : IBaseService<NetworkTypeResponse, NetworkTypeSaveDto, NetworkTypeUpdateDto>
    {
    }
}

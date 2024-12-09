using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Web.Models.ControllersModels.Insurance.NetworkType;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.Insurance
{
    public interface INetworkTypeServiceApi : IBaseServiceApi<NetworkTypeGetAllModel, NetworkTypeGetByIdModel, NetworkTypeSaveDto>
    {
    }
}

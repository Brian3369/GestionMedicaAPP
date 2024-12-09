using GestionMedicaAPP.Application.Dtos.System.Status;
using GestionMedicaAPP.Web.Models.ControllersModels.System.Status;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.System
{
    public interface IStatusServiceApi : IBaseServiceApi<StatusGetAllModel, StatusGetByIdModel, StatusSaveDto>
    {
    }
}

using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Web.Models.ControllersModels.Medical.AvailabilityMode;
using GestionMedicaAPP.Web.Models.ControllersModels.Medical.AvailabilityModes;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.Medical
{
    public interface IAvailabilityModesServiceApi : IBaseServiceApi<AvailabilityModeGetAllModel, AvailabilityModeGetByIdModel, AvailabilityModesSaveDto>
    {
    }
}

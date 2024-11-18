using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Application.Dtos.System.Status;
using GestionMedicaAPP.Application.Response.System.Notifications;
using GestionMedicaAPP.Application.Response.System.Status;

namespace GestionMedicaAPP.Application.Contracts.System
{
    public interface IStatusService : IBaseService<StatusResponse, StatusSaveDto, StatusUpdateDto>
    {
    }
}

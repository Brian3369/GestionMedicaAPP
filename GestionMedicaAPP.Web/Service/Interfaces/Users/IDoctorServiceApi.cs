using GestionMedicaAPP.Application.Dtos.Users.Doctors;
using GestionMedicaAPP.Web.Models.ControllersModels.Users.Doctors;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.Users
{
    public interface IDoctorServiceApi : IBaseServiceApi<DoctorsGetAllModel, DoctorsGetByIdModel, DoctorsSaveDto>
    {
    }
}

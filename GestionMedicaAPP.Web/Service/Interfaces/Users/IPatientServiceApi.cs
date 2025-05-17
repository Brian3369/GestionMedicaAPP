using GestionMedicaAPP.Application.Dtos.Users.Patients;
using GestionMedicaAPP.Web.Models.ControllersModels.Users.Patients;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.Users
{
    public interface IPatientServiceApi : IBaseServiceApi<PatientsGetAllModel, PatientsGetByIdModel, PatientsSaveDto, PatientsUpdateDto>
    {
    }
}

using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Application.Dtos.Medical.Specialties;
using GestionMedicaAPP.Web.Models.ControllersModels.Medical.MedicalRecords;
using GestionMedicaAPP.Web.Models.ControllersModels.Medical.Specialties;
using GestionMedicaAPP.Web.Service.Base;

namespace GestionMedicaAPP.Web.Service.Interfaces.Medical
{
    public interface ISpecialtiesServiceApi : IBaseServiceApi<SpecialtiesGetAllModel, SpecialtiesGetByIdModel, SpecialtiesSaveDto, SpecialtiesUpdateDto>
    {
    }
}

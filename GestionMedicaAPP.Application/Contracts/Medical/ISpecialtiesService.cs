using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Application.Dtos.Medical.Specialties;
using GestionMedicaAPP.Application.Response.Medical.AvailabilityModes;
using GestionMedicaAPP.Application.Response.Medical.Specialties;

namespace GestionMedicaAPP.Application.Contracts.Medical
{
    public interface ISpecialtiesService : IBaseService<SpecialtiesResponse, SpecialtiesSaveDto, SpecialtiesUpdateDto>
    {
    }
}

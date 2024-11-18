using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Application.Response.Insurance.InsuranceProvider;
using GestionMedicaAPP.Application.Response.Medical.AvailabilityModes;

namespace GestionMedicaAPP.Application.Contracts.Medical
{
    public interface IAvailabilityModesService : IBaseService<AvailabilityModesResponse, AvailabilityModesSaveDto, AvailabilityModesUpdate>
    {
    }
}

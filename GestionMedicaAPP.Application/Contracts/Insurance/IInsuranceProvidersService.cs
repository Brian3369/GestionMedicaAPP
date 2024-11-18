using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Application.Response.Appointments.DoctorAvailability;
using GestionMedicaAPP.Application.Response.Insurance.InsuranceProvider;

namespace GestionMedicaAPP.Application.Contracts.Insurance
{
    public interface IInsuranceProvidersService : IBaseService<InsuranceProviderResponse, InsuranceProviderSaveDto, InsuranceProviderUpdateDto>
    {
    }
}

using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Services.appointments;
using GestionMedicaAPP.Application.Services.Insurance;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using GestionMedicaAPP.Persistance.Repositories.Insurance;
using Microsoft.Extensions.DependencyInjection;

namespace GestionMedicaAPP.IOC.Dependencies.Insurance
{
    public static class InsuranceDependency
    {
        public static void AddInsuranceDependecy(this IServiceCollection service)
        {
            service.AddScoped<IInsuranceProvidersRepository, InsuranceProvidersRepository>();
            service.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();

            service.AddTransient<IInsuranceProvidersService, InsuranceProviderService>();
            service.AddTransient<IAppointmentsService, AppointmentsService>();
        }
    }
}

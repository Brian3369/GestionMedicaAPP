using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Services.Medical;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Persistance.Repositories.Medical;
using Microsoft.Extensions.DependencyInjection;

namespace GestionMedicaAPP.IOC.Dependencies.Medical
{
    public static class MedicalDependency
    {
        public static void AddMedicalDependecy(this IServiceCollection service)
        {
            service.AddScoped<IAvailabilityModesRepository, AvailabilityModesRepository>();
            service.AddScoped<IMedicalRecordsRepository, MedicalRecordsRepository>();
            service.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();

            service.AddTransient<IAvailabilityModesService, AvailabilityModesService>();
            service.AddTransient<IMedicalRecordsService, MedicalRecordService>();
            service.AddTransient<ISpecialtiesService, SpecialtiesService>();
        }
    }
}

using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Services.System;
using GestionMedicaAPP.Persistance.Interfaces.System;
using GestionMedicaAPP.Persistance.Repositories.System;
using Microsoft.Extensions.DependencyInjection;

namespace GestionMedicaAPP.IOC.Dependencies.System
{
    public static class SystemDependency
    {
        public static void AddSystemDependecy(this IServiceCollection service)
        {
            service.AddScoped<INotificationsRepository, NotificationsRepository>();
            service.AddScoped<IRolesRepository, RolesRepository>();
            service.AddScoped<IStatusRepository, StatusRepository>();

            service.AddTransient<INotificationsService, NotificationsService>();
            service.AddTransient<IRolesService, RolesService>();
            service.AddTransient<IStatusService, StatusService>();
        }
    }
}

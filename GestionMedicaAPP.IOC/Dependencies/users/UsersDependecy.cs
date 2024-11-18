using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Services.users;
using GestionMedicaAPP.Persistance.Interfaces.users;
using GestionMedicaAPP.Persistance.Repositories.users;
using Microsoft.Extensions.DependencyInjection;

namespace GestionMedicaAPP.IOC.Dependencies.users
{
    public static class UsersDependecy
    {
        public static void AddUsersDependency(this IServiceCollection service)
        {
            service.AddScoped<IDoctorsRepository, DoctorsRepository>();
            service.AddScoped<IPatientsRepository, PatientsRepository>();
            service.AddScoped<IUsersRepository, UsersRepository>();

            service.AddTransient<IDoctorsService, DoctorsService>();
            service.AddTransient<IPatientsService, PatientsService>();
            service.AddTransient<IUsersService, UsersService>();
        }
    }
}

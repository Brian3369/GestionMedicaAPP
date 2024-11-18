using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Services.appointments;
using GestionMedicaAPP.Application.Services.users;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using GestionMedicaAPP.Persistance.Repositories.appointments;
using Microsoft.Extensions.DependencyInjection;

namespace GestionMedicaAPP.IOC.Dependencies.Appointments
{
    public static class AppointmentsDependecy
    {
        public static void AddAppointmentsDependecy(this IServiceCollection service)
        {
            service.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            service.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();

            service.AddTransient<IAppointmentsService, AppointmentsService>();
            service.AddTransient<IDoctorAvailabilityService, DoctorAvailabilityService>();

        }
    }
}

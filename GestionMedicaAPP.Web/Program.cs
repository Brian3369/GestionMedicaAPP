using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Services.appointments;
using GestionMedicaAPP.Application.Services.Insurance;
using GestionMedicaAPP.Application.Services.Medical;
using GestionMedicaAPP.Application.Services.System;
using GestionMedicaAPP.Application.Services.users;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Persistance.Interfaces.System;
using GestionMedicaAPP.Persistance.Interfaces.users;
using GestionMedicaAPP.Persistance.Repositories.appointments;
using GestionMedicaAPP.Persistance.Repositories.Insurance;
using GestionMedicaAPP.Persistance.Repositories.Medical;
using GestionMedicaAPP.Persistance.Repositories.System;
using GestionMedicaAPP.Persistance.Repositories.users;
using GestionMedicaAPP.Web.Service.Interfaces.Appointmets;
using GestionMedicaAPP.Web.Service.ServiceApi.Appointmets;
using GestionMedicaAPP.Web.Service.ServiceApi.Insurance;
using GestionMedicaAPP.Web.Service.ServiceApi.Medical;
using GestionMedicaAPP.Web.Service.ServiceApi.System;
using GestionMedicaAPP.Web.Service.ServiceApi.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GestionMedicaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GestionMedicaDb")));

builder.Services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
builder.Services.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();

builder.Services.AddTransient<IAppointmentsService, AppointmentsService>();
builder.Services.AddTransient<IDoctorAvailabilityService, DoctorAvailabilityService>();

builder.Services.AddScoped<IInsuranceProvidersRepository, InsuranceProvidersRepository>();
builder.Services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();

builder.Services.AddTransient<IInsuranceProvidersService, InsuranceProviderService>();
builder.Services.AddTransient<INetworkTypeService, NetworkTypeService>();

builder.Services.AddScoped<IAvailabilityModesRepository, AvailabilityModesRepository>();
builder.Services.AddScoped<IMedicalRecordsRepository, MedicalRecordsRepository>();
builder.Services.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();

builder.Services.AddTransient<IAvailabilityModesService, AvailabilityModesService>();
builder.Services.AddTransient<IMedicalRecordsService, MedicalRecordService>();
builder.Services.AddTransient<ISpecialtiesService, SpecialtiesService>();

builder.Services.AddScoped<INotificationsRepository, NotificationsRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

builder.Services.AddTransient<INotificationsService, NotificationsService>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<IStatusService, StatusService>();

builder.Services.AddScoped<IDoctorsRepository, DoctorsRepository>();
builder.Services.AddScoped<IPatientsRepository, PatientsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddTransient<IDoctorsService, DoctorsService>();
builder.Services.AddTransient<IPatientsService, PatientsService>();
builder.Services.AddTransient<IUsersService, UsersService>();

////////////////////////////////////////////////////////////////////////////////

builder.Services.AddHttpClient<AppointmentServiceApi>();
builder.Services.AddHttpClient<DoctorAvailabilityServiceApi>();

builder.Services.AddHttpClient<InsuranceProviderServiceApi>();
builder.Services.AddHttpClient<AvailabilityModeServiceApi>();

builder.Services.AddHttpClient<AvailabilityModeServiceApi>();
builder.Services.AddHttpClient<MedicalRecordServiceApi>();
builder.Services.AddHttpClient<SpecialtiesServiceApi>();

builder.Services.AddHttpClient<NotificationServiceApi>();
builder.Services.AddHttpClient<StatusServiceApi>();
builder.Services.AddHttpClient<RoleServiceApi>();

builder.Services.AddHttpClient<UserServiceApi>();
builder.Services.AddHttpClient<PatientServiceApi>();
builder.Services.AddHttpClient<DoctorServiceApi>();










builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

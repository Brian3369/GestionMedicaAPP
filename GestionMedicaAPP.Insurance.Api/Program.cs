using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Insurase;
using GestionMedicaAPP.Persistance.Repositories.Insurase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GestionMedicaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GestionMedicaDb")));

//El registro de cada una de las dependecias Repositorios de appointments. //
builder.Services.AddScoped<IInsuraseProviderRepository, InsuraseProviderRepository>();
builder.Services.AddScoped<INetwordTypeRepository, NetwordTypeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

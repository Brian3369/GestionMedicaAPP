using GestionMedicaAPP.Domain.Entities.users;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.users
{
    public sealed class PatientsRepository(GestionMedicaContext context, ILogger<PatientsRepository> logger) : BaseRepository<Patients>(context), IPatientsRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<PatientsRepository> logger = logger;


    }
}

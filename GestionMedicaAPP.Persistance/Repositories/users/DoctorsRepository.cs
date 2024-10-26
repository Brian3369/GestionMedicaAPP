using GestionMedicaAPP.Domain.Entities.users;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.users
{
    public sealed class DoctorsRepository(GestionMedicaContext context, ILogger<DoctorsRepository> logger) : BaseRepository<Doctors>(context), IDoctorsRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<DoctorsRepository> logger = logger;


    }
}

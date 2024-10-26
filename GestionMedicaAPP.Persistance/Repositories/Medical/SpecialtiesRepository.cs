using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Medical
{
    public sealed class SpecialtiesRepository(GestionMedicaContext context, ILogger<SpecialtiesRepository> logger) : BaseRepository<Specialties>(context), ISpecialtiesRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<SpecialtiesRepository> logger = logger;


    }
}

using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Medical
{
    public sealed class AvailabilityModesRepository(GestionMedicaContext context, ILogger<AvailabilityModesRepository> logger) : BaseRepository<AvailabilityModes>(context), IAvailabilityModesRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<AvailabilityModesRepository> logger = logger;


    }
}

using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.appointments
{
    public sealed class DoctorAvailabilityRepository(GestionMedicaContext context, ILogger<DoctorAvailabilityRepository> logger) : BaseRepository<DoctorAvailability>(context), IDoctorAvailabilityRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<DoctorAvailabilityRepository> logger = logger;

        //public override Task<OperationResult> Save(DoctorAvailability entity)
        //{
        //    return base.Save(entity);
        //}
    }
}


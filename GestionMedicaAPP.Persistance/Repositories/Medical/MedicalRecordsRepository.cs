using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using Microsoft.Extensions.Logging;


namespace GestionMedicaAPP.Persistance.Repositories.Medical
{
    public sealed class MedicalRecordsRepository(GestionMedicaContext context, ILogger<MedicalRecordsRepository> logger) : BaseRepository<MedicalRecords>(context), IMedicalRecordsRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<MedicalRecordsRepository> logger = logger;


    }
}

using GestionMedicaAPP.Domain.Entities.Insurase;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Insurase;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Insurase
{
    public sealed class InsuraseProviderRepository(GestionMedicaContext context, ILogger<InsuraseProviderRepository> logger) : BaseRepository<InsuraseProvider>(context), IInsuraseProviderRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<InsuraseProviderRepository> logger = logger;


    }
}

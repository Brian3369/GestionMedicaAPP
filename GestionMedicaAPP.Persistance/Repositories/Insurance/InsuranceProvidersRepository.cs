using GestionMedicaAPP.Domain.Entities.Insurance;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Insurance
{
    public sealed class InsuranceProvidersRepository(GestionMedicaContext context, ILogger<InsuranceProvidersRepository> logger) : BaseRepository<InsuranceProviders>(context), IInsuranceProvidersRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<InsuranceProvidersRepository> logger = logger;


    }
}

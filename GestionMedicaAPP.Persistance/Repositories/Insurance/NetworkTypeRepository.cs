using GestionMedicaAPP.Domain.Entities.Insurance;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Insurance
{
    public sealed class NetworkTypeRepository(GestionMedicaContext context, ILogger<NetworkTypeRepository> logger) : BaseRepository<NetworkType>(context), INetworkTypeRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<NetworkTypeRepository> logger = logger;


    }
}

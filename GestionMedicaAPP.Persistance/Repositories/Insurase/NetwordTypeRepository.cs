using GestionMedicaAPP.Domain.Entities.Insurase;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Insurase;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Insurase
{
    public sealed class NetwordTypeRepository(GestionMedicaContext context, ILogger<NetwordTypeRepository> logger) : BaseRepository<NetwordType>(context), INetwordTypeRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<NetwordTypeRepository> logger = logger;


    }
}

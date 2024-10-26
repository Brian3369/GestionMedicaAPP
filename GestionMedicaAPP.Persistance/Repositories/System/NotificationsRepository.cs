using GestionMedicaAPP.Domain.Entities.System;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.System;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.System
{

    public sealed class NotificationsRepository(GestionMedicaContext context, ILogger<NotificationsRepository> logger) : BaseRepository<Notifications>(context), INotificationsRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<NotificationsRepository> logger = logger;


    }
}

using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;
using GestionMedicaAPP.Domain.Entities.users;

namespace GestionMedicaAPP.Persistance.Repositories.users
{
    public sealed class UsersRepository(GestionMedicaContext context, ILogger<UsersRepository> logger) : BaseRepository<Users>(context), IUsersRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<UsersRepository> logger = logger;


    }
}

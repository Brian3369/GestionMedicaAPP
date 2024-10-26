using GestionMedicaAPP.Domain.Entities.System;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.System;
using GestionMedicaAPP.Persistance.Models.System;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace GestionMedicaAPP.Persistance.Repositories.System
{
    public sealed class StatusRepository(GestionMedicaContext context, ILogger<StatusRepository> logger) : BaseRepository<Status>(context), IStatusRepository
    {
        private readonly GestionMedicaContext context = context;
        private readonly ILogger<StatusRepository> logger = logger;

        public Task<bool> Exists(Expression<Func<StatusModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAll(Expression<Func<StatusModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(StatusModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Save(StatusModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(StatusModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

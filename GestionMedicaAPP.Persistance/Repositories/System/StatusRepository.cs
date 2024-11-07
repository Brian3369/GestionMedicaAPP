using GestionMedicaAPP.Domain.Entities.System;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.System;
using GestionMedicaAPP.Persistance.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.System
{
    public sealed class StatusRepository(GestionMedicaContext context, ILogger<StatusRepository> logger) : BaseRepository<Status>(context), IStatusRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<StatusRepository> _logger = logger;

        public async override Task<OperationResult> Save(Status entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El estado no puede ser nulo.";
                return result;
            }

            if (string.IsNullOrEmpty(entity.StatusName))
            {
                result.Success = false;
                result.Message = "El nombre del estado es requerido.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando el estado.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(Status entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El estado no puede ser nulo.";
                return result;
            }

            if (string.IsNullOrEmpty(entity.StatusName))
            {
                result.Success = false;
                result.Message = "El nombre del estado es requerido.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el estado.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from status in _context.Status
                                     select new StatusModel()
                                     {
                                         StatusID = status.StatusID,
                                         StatusName = status.StatusName,
                                     }).AsNoTracking()
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los estados.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> GetEntityBy(int id)
        {
            OperationResult result = new OperationResult();

            try
            {
                var status = await (from s in _context.Status
                                    where s.StatusID == id
                                    select new StatusModel()
                                    {
                                        StatusID = s.StatusID,
                                        StatusName = s.StatusName,
                                    }).AsNoTracking()
                                        .FirstOrDefaultAsync();

                if (status == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el estado.";
                    return result;
                }

                result.Data = status;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo el estado.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}

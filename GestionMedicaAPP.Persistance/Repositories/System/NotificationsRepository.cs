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
    public sealed class NotificationsRepository(GestionMedicaContext context, ILogger<NotificationsRepository> logger) : BaseRepository<Notifications>(context), INotificationsRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<NotificationsRepository> _logger = logger;

        public async override Task<OperationResult> Save(Notifications entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La notificación no puede ser nula.";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Message))
            {
                result.Success = false;
                result.Message = "El mensaje de la notificación es requerido.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando la notificación.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(Notifications entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La notificación no puede ser nula.";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Message))
            {
                result.Success = false;
                result.Message = "El mensaje de la notificación es requerido.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando la notificación.";
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
                result.Data = await (from notifications in _context.Notifications
                                     select new NotificationsModel()
                                     {
                                         NotificationID = notifications.NotificationID,
                                         UserID = notifications.UserID,
                                         Message = notifications.Message,
                                         SentAt = notifications.SentAt
                                     }).AsNoTracking()
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo las notificaciones.";
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
                var notification = await (from n in _context.Notifications
                                          where n.NotificationID == id
                                          select new NotificationsModel()
                                          {
                                              NotificationID = n.NotificationID,
                                              UserID = n.UserID,
                                              Message = n.Message,
                                              SentAt = n.SentAt
                                          }).AsNoTracking()
                                        .FirstOrDefaultAsync();

                if (notification == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró la notificación.";
                    return result;
                }

                result.Data = notification;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo la notificación.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
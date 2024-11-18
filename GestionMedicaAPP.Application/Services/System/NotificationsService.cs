using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Application.Response.System.Notifications;
using GestionMedicaAPP.Persistance.Interfaces.System;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.System
{
    public class NotificationsService : INotificationsService
    {
        private readonly INotificationsRepository _NotificationsRepository;
        private readonly ILogger<NotificationsService> _logger;
        public NotificationsService(INotificationsRepository NotificationsRepository, ILogger<NotificationsService> logger)
        {
            _logger = logger;
            _NotificationsRepository = NotificationsRepository;
        }
        public async Task<NotificationsResponse> GetAll()
        {
            NotificationsResponse NotificationssResponse = new NotificationsResponse();

            try
            {
                var result = await _NotificationsRepository.GetAll();

                if (!result.Success)
                {
                    NotificationssResponse.Message = result.Message;
                    NotificationssResponse.IsSuccess = result.Success;
                    return NotificationssResponse;
                }

                NotificationssResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                NotificationssResponse.IsSuccess = false;
                NotificationssResponse.Model = "Error obteniendo las notificaciones";
                _logger.LogError(NotificationssResponse.Message, ex.ToString());
            }

            return NotificationssResponse;
        }

        public Task<NotificationsResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationsResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationsResponse> SaveAsync(NotificationsSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationsResponse> UpdateAsync(NotificationsUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

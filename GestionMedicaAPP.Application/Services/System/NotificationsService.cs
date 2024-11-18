using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Application.Response.System.Notifications;
using GestionMedicaAPP.Application.Services.Medical;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
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
        public Task<NotificationsResponse> GetAll()
        {
            throw new NotImplementedException();
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

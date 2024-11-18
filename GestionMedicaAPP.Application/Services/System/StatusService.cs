using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Status;
using GestionMedicaAPP.Application.Response.System.Status;
using GestionMedicaAPP.Persistance.Interfaces.System;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.System
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _StatusRepository;
        private readonly ILogger<StatusService> _logger;
        public StatusService(IStatusRepository StatusRepository, ILogger<StatusService> logger)
        {
            _logger = logger;
            _StatusRepository = StatusRepository;
        }
        public Task<StatusResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<StatusResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<StatusResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<StatusResponse> SaveAsync(StatusSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<StatusResponse> UpdateAsync(StatusUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

﻿using GestionMedicaAPP.Application.Contracts.System;
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
        public async Task<StatusResponse> GetAll()
        {
            StatusResponse StatussResponse = new StatusResponse();

            try
            {
                var result = await _StatusRepository.GetAll();

                if (!result.Success)
                {
                    StatussResponse.Message = result.Message;
                    StatussResponse.IsSuccess = result.Success;
                    return StatussResponse;
                }

                StatussResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                StatussResponse.IsSuccess = false;
                StatussResponse.Model = "Error obteniedo los Status";
                _logger.LogError(StatussResponse.Message, ex.ToString());
            }

            return StatussResponse;
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

using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Roles;
using GestionMedicaAPP.Application.Response.System.Roles;
using GestionMedicaAPP.Persistance.Interfaces.System;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.System
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _RolesRepository;
        private readonly ILogger<RolesService> _logger;
        public RolesService(IRolesRepository RolesRepository, ILogger<RolesService> logger)
        {
            _logger = logger;
            _RolesRepository = RolesRepository;
        }
        public Task<RolesResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RolesResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<RolesResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<RolesResponse> SaveAsync(RolesSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<RolesResponse> UpdateAsync(RolesUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

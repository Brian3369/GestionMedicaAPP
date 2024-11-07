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
    public sealed class RolesRepository(GestionMedicaContext context, ILogger<RolesRepository> logger) : BaseRepository<Roles>(context), IRolesRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<RolesRepository> _logger = logger;

        public async override Task<OperationResult> Save(Roles entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El rol no puede ser nulo.";
                return result;
            }

            if (string.IsNullOrEmpty(entity.RoleName))
            {
                result.Success = false;
                result.Message = "El nombre del rol es requerido.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando el rol.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(Roles entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El rol no puede ser nulo.";
                return result;
            }

            if (string.IsNullOrEmpty(entity.RoleName))
            {
                result.Success = false;
                result.Message = "El nombre del rol es requerido.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el rol.";
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
                result.Data = await (from roles in _context.Roles
                                     select new RolesModel()
                                     {
                                         RoleID = roles.RoleID,
                                         RoleName = roles.RoleName
                                     }).AsNoTracking()
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los roles.";
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
                var role = await (from r in _context.Roles
                                  where r.RoleID == id
                                  select new RolesModel()
                                  {
                                      RoleID = r.RoleID,
                                      RoleName = r.RoleName
                                  }).AsNoTracking()
                                        .FirstOrDefaultAsync();

                if (role == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el rol.";
                    return result;
                }

                result.Data = role;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo el rol.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
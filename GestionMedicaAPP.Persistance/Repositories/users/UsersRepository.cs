using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;
using GestionMedicaAPP.Domain.Entities.users;
using GestionMedicaAPP.Domain.Result;
using Microsoft.EntityFrameworkCore;

namespace GestionMedicaAPP.Persistance.Repositories.users
{
    public class UsersRepository(GestionMedicaContext gestionMedicaContext, ILogger<UsersRepository> logger) : BaseRepository<Users>(gestionMedicaContext), IUsersRepository
    {
        private readonly GestionMedicaContext _context = gestionMedicaContext;
        private readonly ILogger<UsersRepository> _logger = logger;

        public async override Task<OperationResult> Save(Users entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El usuario no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando el usuario.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(Users entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El usuario no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el usuario.";
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
                result.Data = await _context.Users
                    .AsNoTracking()
                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los usuarios.";
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
                var user = await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.UserID == id);

                if (user == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el usuario.";
                    return result;
                }

                result.Data = user;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo el usuario.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
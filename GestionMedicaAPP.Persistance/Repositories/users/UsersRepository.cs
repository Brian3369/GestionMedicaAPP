using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;
using GestionMedicaAPP.Domain.Entities.users;
using GestionMedicaAPP.Domain.Result;
using Microsoft.EntityFrameworkCore;
using GestionMedicaAPP.Persistance.Models.users;

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
            if (await base.Exists(u => u.UserID == entity.UserID && u.Email == entity.Email))
            {
                result.Success = false;
                result.Message = "Ya existe un usaurio con este correo";
                return result;
            }

            if (entity.FirstName == null || entity.LastName == null || entity.Email == null || entity.Password == null)
            {
                result.Success = false;
                result.Message = "Debe llenar todos los datos";
                return result;
            }

            if (entity.RoleID == null)
            {
                result.Success = false;
                result.Message = "Deve asignar un roll";
                return result;
            }

            try
            {
                entity.IsActive = true;
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
            Users? usersToUpdate = await _context.Users.FindAsync(entity.UserID);

            if (usersToUpdate == null)
            {
                result.Success = false;
                result.Message = "El usuario no existe.";
                return result;
            }

            if (entity.RoleID == null)
            {
                result.Success = false;
                result.Message = "El rol es requerido.";
                return result;
            }

            if (entity.FirstName == null || entity.LastName == null || entity.Email == null || entity.Password == null)
            {
                result.Success = false;
                result.Message = "Debe llenar todos los datos";
                return result;
            }

            try
            {
                usersToUpdate.FirstName = entity.FirstName;
                usersToUpdate.LastName = entity.LastName;
                usersToUpdate.Email = entity.Email;
                usersToUpdate.Password = entity.Password;
                usersToUpdate.RoleID = entity.RoleID;
                usersToUpdate.UpdatedAt = entity.UpdatedAt;
                usersToUpdate.IsActive = entity.IsActive;

                result = await base.Update(usersToUpdate);
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
                result.Data = await (from users in _context.Users
                                     where users.IsActive == true
                                     select new UsersModel()
                                     {
                                         UserID = users.UserID,
                                         FirstName = users.FirstName,
                                         LastName = users.LastName,
                                         Email = users.Email,
                                         Password = users.Password,
                                         RoleID = users.RoleID,
                                         CreatedAt = users.CreatedAt,
                                         UpdatedAt = users.UpdatedAt,
                                         IsActive = users.IsActive
                                     }).AsNoTracking()
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
                var user = await (from users in this._context.Users
                                         where users.UserID == id
                                         select new UsersModel()
                                         {
                                             UserID = users.UserID,
                                             FirstName = users.FirstName,
                                             LastName = users.LastName,
                                             Email = users.Email,
                                             Password = users.Password,
                                             RoleID = users.RoleID,
                                             CreatedAt = users.CreatedAt,
                                             UpdatedAt = users.UpdatedAt,
                                             IsActive = users.IsActive
                                         })
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

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
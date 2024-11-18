using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users;
using GestionMedicaAPP.Application.Response.Users.users;
using GestionMedicaAPP.Domain.Entities.users;
using GestionMedicaAPP.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILogger<UsersService> _logger;

        public UsersService(IUsersRepository usersRepository, ILogger<UsersService> logger)
        {
            _usersRepository = usersRepository;
            _logger = logger;
        }

        public async Task<UsersResponse> GetAll()
        {
            UsersResponse usersResponse = new UsersResponse();

            try
            {
                var result = await _usersRepository.GetAll();

                if (!result.Success)
                {
                    usersResponse.Message = result.Message;
                    usersResponse.IsSuccess = result.Success;
                    return usersResponse;
                }

                usersResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                usersResponse.IsSuccess = false;
                usersResponse.Model = "Error obteniendo los usuarios";
                _logger.LogError(usersResponse.Message, ex.ToString());
            }

            return usersResponse;
        }

        public async Task<UsersResponse> GetById(int Id)
        {
            UsersResponse usersResponse = new UsersResponse();

            try
            {
                var result = await _usersRepository.GetEntityBy(Id);

                if (!result.Success)
                {
                    usersResponse.Message = result.Message;
                    usersResponse.IsSuccess = result.Success;
                    return usersResponse;
                }

                usersResponse.Model = result.Data;
                usersResponse.IsSuccess = result.Success;
            }

            catch (Exception ex)
            {

                usersResponse.IsSuccess = false;
                usersResponse.Model = "Error obteniendo el usuario";
                _logger.LogError(usersResponse.Message, ex.ToString());
            }

            return usersResponse;
        }

        public async Task<UsersResponse> SaveAsync(UsersSaveDto dto)
        {
            UsersResponse usersResponse = new UsersResponse();

            if (dto == null)
            {
                usersResponse.IsSuccess = false;
                usersResponse.Message = "El usuario no puede ser nulo.";
                return usersResponse;
            }

            try
            {
                Users users = new Users();

                users.FirstName = dto.FirstName;
                users.LastName = dto.LastName;
                users.Email = dto.Email;
                users.Password = dto.Password;
                users.RoleID = dto.RoleID;
                users.UpdatedAt = dto.UpdatedAt;
                users.CreatedAt = dto.CreatedAt;
                users.IsActive = true;

                var result = await _usersRepository.Save(users);
                usersResponse.IsSuccess = result.Success;
                usersResponse.Message = result.Message;
            }
            catch (Exception ex)
            {
                usersResponse.IsSuccess = false;
                usersResponse.Message = "Error guardando el usuario";
                _logger.LogError(usersResponse.Message, ex.ToString());
            }
            return usersResponse;
        }

        public async Task<UsersResponse> UpdateAsync(UsersUpdateDto dto)
        {
            UsersResponse usersResponse = new UsersResponse();

            try
            {
                var resultEntity = await _usersRepository.GetEntityBy(dto.UserID);

                if (!resultEntity.Success)
                {
                    usersResponse.IsSuccess = resultEntity.Success;
                    usersResponse.Message = resultEntity.Message;
                    return usersResponse;
                }

                var data = resultEntity.Data;
                if (data == null)
                {
                    usersResponse.IsSuccess = false;
                    usersResponse.Message = "Los datos del usuario no están disponibles.";
                    return usersResponse;
                }

                Users users = data as Users ?? new Users
                {
                    UserID = (int)(data.GetType().GetProperty("UserID")?.GetValue(data) ?? 0),
                    FirstName = data.GetType().GetProperty("FirstName")?.GetValue(data)?.ToString(),
                    LastName = data.GetType().GetProperty("LastName")?.GetValue(data)?.ToString(),
                    Email = data.GetType().GetProperty("Email")?.GetValue(data)?.ToString(),
                    Password = data.GetType().GetProperty("Password")?.GetValue(data)?.ToString(),
                    RoleID = (int)(data.GetType().GetProperty("RoleID")?.GetValue(data) ?? 0),
                    CreatedAt = (DateTime)(data.GetType().GetProperty("CreatedAt")?.GetValue(data) ?? DateTime.MinValue),
                    UpdatedAt = (DateTime)(data.GetType().GetProperty("UpdatedAt")?.GetValue(data) ?? DateTime.MinValue),
                    IsActive = (bool)(data.GetType().GetProperty("IsActive")?.GetValue(data) ?? false)
                };

                users.UserID = dto.UserID;
                users.FirstName = dto.FirstName;
                users.LastName = dto.LastName;
                users.Email = dto.Email;
                users.Password = dto.Password;
                users.RoleID = dto.RoleID;
                users.UpdatedAt = dto.UpdatedAt;
                users.CreatedAt = dto.CreatedAt;
                users.IsActive = dto.IsActive;

                var result = await _usersRepository.Update(users);
                usersResponse.IsSuccess = result.Success;
                usersResponse.Message = result.Success ? "Usuario actualizado con éxito." : "Error al actualizar el usuario.";
            }
            catch (Exception ex)
            {
                usersResponse.IsSuccess = false;
                usersResponse.Message = "Error actualizando el usuario.";
                _logger.LogError(usersResponse.Message, ex.ToString());
            }

            return usersResponse;
        }

        public async Task<UsersResponse> RemoveById(int id)
        {
            UsersResponse usersResponse = new UsersResponse();

            try
            {
                var resultEntity = await _usersRepository.GetEntityBy(id);

                if (!resultEntity.Success)
                {
                    usersResponse.IsSuccess = resultEntity.Success;
                    usersResponse.Message = resultEntity.Message;
                    return usersResponse;
                }

                var data = resultEntity.Data;

                Users users = new Users
                {
                    UserID = data.UserID,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    Password = data.Password,
                    RoleID = data.RoleID,
                    UpdatedAt = data.UpdatedAt,
                    CreatedAt = data.CreatedAt,
                    IsActive = data.IsActive
                };

                var deleteResult = await _usersRepository.Remove(users);

                usersResponse.IsSuccess = deleteResult.Success;
                usersResponse.Message = deleteResult.Message;
            }
            catch (Exception ex)
            {
                usersResponse.IsSuccess = false;
                usersResponse.Message = "Error eliminando el usuario.";
                _logger.LogError(usersResponse.Message, ex.ToString());
            }

            return usersResponse;
        }
    }
}

using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users;
using GestionMedicaAPP.Application.Response.Users;
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
            if (usersRepository is null)
            {
                throw new ArgumentNullException(nameof(usersRepository));
            }
            _usersRepository = usersRepository;
        }
        public async Task<UsersResponse> GetAll()
        {
            UsersResponse usersResponse = new UsersResponse();

            try
            {
                var result = await _usersRepository.GetAll();

                List<GetUsersDto> users = ((List<Users>)result.Data)
                                                   .Select(users => new GetUsersDto()
                                                   {
                                                       UserID = users.UserID,
                                                       FirstName = users.FirstName,
                                                       LastName = users.LastName,
                                                       RoleID = users.RoleID,
                                                       IsActive = users.IsActive  
                                                   }).ToList();

                usersResponse.IsSuccess = result.Success;
                usersResponse.Model = result;
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

                Users users = (Users)result.Data;

                GetUsersDto getUsersDto = new GetUsersDto()
                {
                    UserID = users.UserID,
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    RoleID = users.RoleID,
                    IsActive = users.IsActive
                };

                usersResponse.IsSuccess = result.Success;
                usersResponse.Model = result.Data;
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

            try
            {
                Users users = new Users();

                users.FirstName = dto.FirstName;
                users.LastName = dto.LastName;
                users.Email = dto.Email;
                users.Password = dto.Password;
                users.RoleID = dto.RoleID;
                users.CreatedAt = dto.CreatedAt;
                users.UpdatedAt = dto.UpdatedAt;
                users.IsActive = dto.IsActive;

                var result = await _usersRepository.Save(users);
                result.Message = "El usuario fue creado correctamente.";
            }
            catch (Exception ex)
            {
                usersResponse.IsSuccess = false;
                usersResponse.Model = "Error guardando el usuario";
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
                Users usersToUpdate = (Users)resultEntity.Data;

                usersToUpdate.FirstName = dto.FirstName;
                usersToUpdate.LastName = dto.LastName;
                usersToUpdate.Email = dto.Email;
                usersToUpdate.Password = dto.Password;
                usersToUpdate.RoleID = dto.RoleID;
                usersToUpdate.UpdatedAt = dto.UpdatedAt;
                usersToUpdate.IsActive = dto.IsActive;

                var result = await _usersRepository.Update(usersToUpdate);
                result.Message = "El usuario fue actualizado correctamente.";
            }
            catch (Exception ex)
            {
                usersResponse.IsSuccess = false;
                usersResponse.Model = "Error actualizando el usuario";
                _logger.LogError(usersResponse.Message, ex.ToString());
            }
            return usersResponse;
        }
    }
}

using GestionMedicaAPP.Persistance.Interfaces.users;
using GestionMedicaAPP.Domain.Entities.users;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> Get()
        {
            var result = await _usersRepository.GetAll();
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _usersRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveUsers")]
        public async Task<IActionResult> Post([FromBody] Users users)
        {
            var result = await _usersRepository.Save(users);
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateUsers")]
        public async Task<IActionResult> Put(int id, [FromBody] Users users)
        {
            var result = await _usersRepository.Update(users);
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveUser")]
        public async Task<IActionResult> get(int id)
        {
            var result = await _usersRepository.RemoveById(id);
            if (result.Success)
                return BadRequest(result);
                
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users;

namespace GestionMedicaAPP.users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> Get()
        {
            var result = await _usersService.GetAll();
            if(!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _usersService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveUsers")]
        public async Task<IActionResult> Post([FromBody] UsersSaveDto usersSaveDto)
        {
            var result = await _usersService.SaveAsync(usersSaveDto);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateUsers")]
        public async Task<IActionResult> Put([FromBody] UsersUpdateDto usersUpdateDto)
        {
            var result = await _usersService.UpdateAsync(usersUpdateDto);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveUser")]
        public async Task<IActionResult> get(int id)
        {
            var result = await _usersService.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);
                
            return Ok(result);
        }
    }
}

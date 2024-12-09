using GestionMedicaAPP.Domain.Entities.System;
using GestionMedicaAPP.Persistance.Interfaces.System;
using GestionMedicaAPP.Persistance.Repositories.System;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository) 
        {
            _rolesRepository = rolesRepository;
        }


        [HttpGet("GetRoles")]
        public async Task<IActionResult> Get()
        {
            var result = await _rolesRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetRolesById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _rolesRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveRoles")]
        public async Task<IActionResult> Post([FromBody] Roles roles)
        {
            var result = await _rolesRepository.Save(roles);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateRoles")]
        public async Task<IActionResult> Put(int id, [FromBody] Roles roles)
        {
            var result = await _rolesRepository.Update(roles);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveRoles")]
        public async Task<IActionResult> Remove(Roles roles)
        {
            var result = await _rolesRepository.Remove(roles);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

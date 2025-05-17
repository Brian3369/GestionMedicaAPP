using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Roles;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> Get()
        {
            var result = await _rolesService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _rolesService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveRoles")]
        public async Task<IActionResult> Post([FromBody] RolesSaveDto roles)
        {
            var result = await _rolesService.SaveAsync(roles);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateRoles")]
        public async Task<IActionResult> Put([FromBody] RolesUpdateDto roles)
        {
            var result = await _rolesService.UpdateAsync(roles);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveRoles")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _rolesService.RemoveById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Status;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("GetStatus")]
        public async Task<IActionResult> Get()
        {
            var result = await _statusService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _statusService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveStatus")]
        public async Task<IActionResult> Post([FromBody] StatusSaveDto status)
        {
            var result = await _statusService.SaveAsync(status);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> Put([FromBody] StatusUpdateDto status)
        {
            var result = await _statusService.UpdateAsync(status);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveStatus")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _statusService.RemoveById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
using GestionMedicaAPP.Domain.Entities.System;
using GestionMedicaAPP.Persistance.Interfaces.System;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionMedicaAPP.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }


        [HttpGet("GetStatus")]
        public async Task<IActionResult> Get()
        {
            var result = await _statusRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetStatusById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _statusRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveStatus")]
        public async Task<IActionResult> Post([FromBody] Status status)
        {
            var result = await _statusRepository.Save(status);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> Put(int id, [FromBody] Status status)
        {
            var result = await _statusRepository.Update(status);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveStatus")]
        public async Task<IActionResult> Remove(Status status)
        {
            var result = await _statusRepository.Remove(status);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

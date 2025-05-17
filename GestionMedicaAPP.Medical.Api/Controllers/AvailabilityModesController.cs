using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Domain.Entities.Medical;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionMedicaAPP.Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityModesController : ControllerBase
    {
        private readonly IAvailabilityModesService _availabilityModesService;
        public AvailabilityModesController(IAvailabilityModesService availabilityModesService)
        {
            _availabilityModesService = availabilityModesService;
        }

        [HttpGet("GetAvailabilityModes")]
        public async Task<IActionResult> Get()
        {
           var result = await _availabilityModesService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetAvailabilityModesById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _availabilityModesService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveAvailabilityModes")]
        public async Task<IActionResult> Post([FromBody] AvailabilityModesSaveDto availabilityModes)
        {
            var result = await _availabilityModesService.SaveAsync(availabilityModes);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateAvailabilityModes")]
        public async Task<IActionResult> Put([FromBody] AvailabilityModesUpdateDto availabilityModes)
        {
            var result = await _availabilityModesService.UpdateAsync(availabilityModes);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveAvailabilityModes")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _availabilityModesService.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

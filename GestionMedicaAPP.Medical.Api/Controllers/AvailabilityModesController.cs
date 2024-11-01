using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Persistance.Repositories.Medical;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionMedicaAPP.Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityModesController : ControllerBase
    {
        private readonly IAvailabilityModesRepository _availabilityModesRepository;
        public AvailabilityModesController(IAvailabilityModesRepository availabilityModesRepository)
        {
            _availabilityModesRepository = availabilityModesRepository;
        }

        [HttpGet("GetAvailabilityModes")]
        public async Task<IActionResult> Get()
        {
           var result = await _availabilityModesRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetAvailabilityModesById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _availabilityModesRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveAvailabilityModes")]
        public async Task<IActionResult> Post([FromBody] AvailabilityModes availabilityModes)
        {
            var result = await _availabilityModesRepository.Save(availabilityModes);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateAvailabilityModes")]
        public async Task<IActionResult> Put(int id, [FromBody] AvailabilityModes availabilityModes)
        {
            var result = await _availabilityModesRepository.Update(availabilityModes);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveAvailabilityModes")]
        public async Task<IActionResult> Remove(AvailabilityModes availabilityModes)
        {
            var result = await _availabilityModesRepository.Remove(availabilityModes);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

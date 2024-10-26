using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
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
        // GET: api/<AsientoController>
        [HttpGet("GetAvailabilityModes")]
        public async Task<IActionResult> Get()
        {
            var result = await _availabilityModesRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<AvailabilityModesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AvailabilityModesController>
        [HttpPost("SaveAvailabilityMode")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AvailabilityModesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AvailabilityModesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

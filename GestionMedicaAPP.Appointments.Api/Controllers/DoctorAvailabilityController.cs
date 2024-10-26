using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using GestionMedicaAPP.Persistance.Repositories.appointments;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Appointment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
        public DoctorAvailabilityController(IDoctorAvailabilityRepository doctorAvailabilityRepository) 
        {
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
        }

        // GET: api/<AsientoController>
        [HttpGet("GetDoctorAvailability")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorAvailabilityRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<AsientoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AsientoController>
        [HttpPost("SaveDoctorAvailability")]
        public async Task<IActionResult> Post([FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabilityRepository.Save(doctorAvailability);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT api/<AsientoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AsientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

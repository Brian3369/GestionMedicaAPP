using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Appointment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsRepository _appointmentsRepository;
        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }
        // GET: api/<AsientoController>
        [HttpGet ("GetAppointment")]
        public async Task<IActionResult> Get()
        {
            var result = await _appointmentsRepository.GetAll();
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
        [HttpPost("SaveAppointment")]
        public async Task<IActionResult> Post([FromBody] Appointments appointments)
        {
            var result = await _appointmentsRepository.Save(appointments);
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
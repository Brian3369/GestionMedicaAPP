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

        [HttpGet("GetAppointments")]
        public async Task<IActionResult> Get()
        {
            var result = await _appointmentsRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetAppointmentsById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _appointmentsRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveAppointments")]
        public async Task<IActionResult> Post([FromBody] Appointments appointments)
        {
            var result = await _appointmentsRepository.Save(appointments);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateAppointments")]
        public async Task<IActionResult> Put(int id, [FromBody] Appointments appointments)
        {
            var result = await _appointmentsRepository.Update(appointments);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveAppointments")]
        public async Task<IActionResult> Remove(Appointments appointments)
        {
            var result = await _appointmentsRepository.Remove(appointments);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
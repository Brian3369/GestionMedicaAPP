using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Domain.Entities.appointmets;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Appointment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentsService;
        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        [HttpGet("GetAppointments")]
        public async Task<IActionResult> Get()
        {
            var result = await _appointmentsService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetAppointmentsById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _appointmentsService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveAppointments")]
        public async Task<IActionResult> Post([FromBody] AppointmentsSaveDto appointments)
        {
            var result = await _appointmentsService.SaveAsync(appointments);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateAppointments")]
        public async Task<IActionResult> Put([FromBody] AppointmentsUpdateDto appointments)
        {
            var result = await _appointmentsService.UpdateAsync(appointments);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveAppointments")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _appointmentsService.RemoveById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
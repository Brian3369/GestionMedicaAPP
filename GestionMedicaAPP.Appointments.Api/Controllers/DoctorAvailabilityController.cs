using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Appointment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;
        public DoctorAvailabilityController(IDoctorAvailabilityService doctorAvailabilityService) 
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }
 
        [HttpGet("GetDoctorAvailability")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorAvailabilityService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetDoctorAvailabilityById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorAvailabilityService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveDoctorAvailability")]
        public async Task<IActionResult> Post([FromBody] DoctorAvailabilitySaveDto doctorAvailability)
        {
            var result = await _doctorAvailabilityService.SaveAsync(doctorAvailability);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateDoctorAvailability")]
        public async Task<IActionResult> Put([FromBody] DoctorAvailabilityUpdateDto doctorAvailability)
        {
            var result = await _doctorAvailabilityService.UpdateAsync(doctorAvailability);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveDoctorAvailability")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _doctorAvailabilityService.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

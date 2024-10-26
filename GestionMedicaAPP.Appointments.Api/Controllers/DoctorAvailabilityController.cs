using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Domain.Entities.System;
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
 
        [HttpGet("GetDoctorAvailability")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorAvailabilityRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetDoctorAvailabilityById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorAvailabilityRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveDoctorAvailability")]
        public async Task<IActionResult> Post([FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabilityRepository.Save(doctorAvailability);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateDoctorAvailability")]
        public async Task<IActionResult> Put(int id, [FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabilityRepository.Update(doctorAvailability);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveDoctorAvailability")]
        public async Task<IActionResult> Remove(DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabilityRepository.Remove(doctorAvailability);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

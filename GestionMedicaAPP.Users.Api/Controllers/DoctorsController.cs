using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsService _doctorsService;
        public DoctorsController(IDoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        [HttpGet("GetDoctors")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorsService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorsService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveDoctors")]
        public async Task<IActionResult> Post([FromBody] DoctorsSaveDto doctors)
        {
            var result = await _doctorsService.SaveAsync(doctors);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateDoctors")]
        public async Task<IActionResult> Put([FromBody] DoctorsUpdateDto doctors)
        {
            var result = await _doctorsService.UpdateAsync(doctors);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveDoctors")]
        public async Task<IActionResult> get(int id)
        {
            var result = await _doctorsService.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

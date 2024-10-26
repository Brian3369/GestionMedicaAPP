using GestionMedicaAPP.Domain.Entities.users;
using GestionMedicaAPP.Persistance.Interfaces.users;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository _doctorsRepository;
        public DoctorsController(IDoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        [HttpGet("GetDoctors")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorsRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorsRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveDoctors")]
        public async Task<IActionResult> Post([FromBody] Doctors doctors)
        {
            var result = await _doctorsRepository.Save(doctors);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateDoctors")]
        public async Task<IActionResult> Put(int id, [FromBody] Doctors doctors)
        {
            var result = await _doctorsRepository.Update(doctors);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveDoctors")]
        public async Task<IActionResult> Remove(Doctors doctors)
        {
            var result = await _doctorsRepository.Remove(doctors);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

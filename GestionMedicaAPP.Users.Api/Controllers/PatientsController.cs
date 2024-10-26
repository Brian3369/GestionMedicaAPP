using GestionMedicaAPP.Domain.Entities.users;
using GestionMedicaAPP.Persistance.Interfaces.users;
using GestionMedicaAPP.Persistance.Repositories.users;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository _patientsRepository;
        public PatientsController(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }
        [HttpGet("GetPatients")]
        public async Task<IActionResult> Get()
        {
            var result = await _patientsRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _patientsRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SavePatients")]
        public async Task<IActionResult> Post([FromBody] Patients patiens)
        {
            var result = await _patientsRepository.Save(patiens);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdatePatients")]
        public async Task<IActionResult> Put(int id, [FromBody] Patients patiens)
        {
            var result = await _patientsRepository.Update(patiens);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemovePatients")]
        public async Task<IActionResult> Remove(Patients patiens)
        {
            var result = await _patientsRepository.Remove(patiens);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

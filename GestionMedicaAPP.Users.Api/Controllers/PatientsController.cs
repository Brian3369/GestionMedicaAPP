using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users.Patients;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _patientsService;
        public PatientsController(IPatientsService patientsService)
        {
            _patientsService = patientsService;
        }
        [HttpGet("GetPatients")]
        public async Task<IActionResult> Get()
        {
            var result = await _patientsService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _patientsService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SavePatients")]
        public async Task<IActionResult> Post([FromBody] PatientsSaveDto patiens)
        {
            var result = await _patientsService.SaveAsync(patiens);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdatePatients")]
        public async Task<IActionResult> Put([FromBody] PatientsUpdateDto patiens)
        {
            var result = await _patientsService.UpdateAsync(patiens);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemovePatients")]
        public async Task<IActionResult> get(int id)
        {
            var result = await _patientsService.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

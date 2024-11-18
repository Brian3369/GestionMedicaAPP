using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.Specialties;
using GestionMedicaAPP.Domain.Entities.Medical;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Medical.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtiesService _specialtiesService;
        public SpecialtiesController(ISpecialtiesService specialtiesService) 
        {
            _specialtiesService = specialtiesService;
        }

        [HttpGet("GetSpecialties")]
        public async Task<IActionResult> Get()
        {
            var result = await _specialtiesService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetSpecialtiesById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _specialtiesService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveSpecialties")]
        public async Task<IActionResult> Post([FromBody] SpecialtiesSaveDto specialties)
        {
            var result = await _specialtiesService.SaveAsync(specialties);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateSpecialties")]
        public async Task<IActionResult> Put([FromBody] SpecialtiesUpdateDto specialties)
        {
            var result = await _specialtiesService.UpdateAsync(specialties);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveSpecialties")]
        public async Task<IActionResult> get(int id)
        {
            var result = await _specialtiesService.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

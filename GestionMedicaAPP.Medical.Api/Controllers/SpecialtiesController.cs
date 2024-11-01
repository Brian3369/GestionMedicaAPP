using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Persistance.Repositories.Medical;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Medical.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtiesRepository _specialtiesRepository;
        public SpecialtiesController(ISpecialtiesRepository specialtiesRepository) 
        {
            _specialtiesRepository = specialtiesRepository;
        }

        [HttpGet("GetSpecialties")]
        public async Task<IActionResult> Get()
        {
            var result = await _specialtiesRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetSpecialtiesById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _specialtiesRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveSpecialties")]
        public async Task<IActionResult> Post([FromBody] Specialties specialties)
        {
            var result = await _specialtiesRepository.Save(specialties);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateSpecialties")]
        public async Task<IActionResult> Put(int id, [FromBody] Specialties specialties)
        {
            var result = await _specialtiesRepository.Update(specialties);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveSpecialties")]
        public async Task<IActionResult> Remove(Specialties specialties)
        {
            var result = await _specialtiesRepository.Remove(specialties);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

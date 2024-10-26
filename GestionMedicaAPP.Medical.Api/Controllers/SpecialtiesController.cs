using GestionMedicaAPP.Persistance.Interfaces.Medical;
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
        // GET: api/<AsientoController>
        [HttpGet("GetSpecialties")]
        public async Task<IActionResult> Get()
        {
            var result = await _specialtiesRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<AsientoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AsientoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AsientoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AsientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

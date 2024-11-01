using GestionMedicaAPP.Domain.Entities.Insurance;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionMedicaAPP.Insurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkTypeController : ControllerBase
    {
        private readonly INetworkTypeRepository _NetwordTypeRepository;
        public NetworkTypeController(INetworkTypeRepository NetwordTypeRepository)
        {
            _NetwordTypeRepository = NetwordTypeRepository;
        }

        [HttpGet("GetNetwordType")]
        public async Task<IActionResult> Get()
        {
            var result = await _NetwordTypeRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetNetwordTypeById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _NetwordTypeRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveNetwordType")]
        public async Task<IActionResult> Post([FromBody] NetworkType networdType)
        {
            var result = await _NetwordTypeRepository.Save(networdType);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateNetwordType")]
        public async Task<IActionResult> Put(int id, [FromBody] NetworkType networdType)
        {
            var result = await _NetwordTypeRepository.Update(networdType);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveNetwordType")]
        public async Task<IActionResult> Remove(NetworkType networdType)
        {
            var result = await _NetwordTypeRepository.Remove(networdType);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

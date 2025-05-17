using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
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
        private readonly INetworkTypeService _NetwordTypeService;
        public NetworkTypeController(INetworkTypeService NetwordTypeService)
        {
            _NetwordTypeService = NetwordTypeService;
        }

        [HttpGet("GetNetworkType")]
        public async Task<IActionResult> Get()
        {
            var result = await _NetwordTypeService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetNetworkTypeById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _NetwordTypeService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveNetworkType")]
        public async Task<IActionResult> Post([FromBody] NetworkTypeSaveDto networdType)
        {
            var result = await _NetwordTypeService.SaveAsync(networdType);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateNetworkType")]
        public async Task<IActionResult> Put([FromBody] NetworkTypeUpdateDto networdType)
        {
            var result = await _NetwordTypeService.UpdateAsync(networdType);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveNetworkType")]
        public async Task<IActionResult> get(int id)
        {
            var result = await _NetwordTypeService.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

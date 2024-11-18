using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Insurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceProvidersController : ControllerBase
    {
        private readonly IInsuranceProvidersService _insuranceProvidersService;
        public InsuranceProvidersController(IInsuranceProvidersService insuranceProviderService)
        {
            _insuranceProvidersService = insuranceProviderService;
        }

        [HttpGet("GetInsuranceProvider")]
        public async Task<IActionResult> Get()
        {
            var result = await _insuranceProvidersService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetInsuranceProviderById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _insuranceProvidersService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveInsuranceProvider")]
        public async Task<IActionResult> Post([FromBody] InsuranceProviderSaveDto insuranceProviders)
        {
            var result = await _insuranceProvidersService.SaveAsync(insuranceProviders);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateInsuranceProvider")]
        public async Task<IActionResult> Put([FromBody] InsuranceProviderUpdateDto insuranceProviders)
        {
            var result = await _insuranceProvidersService.UpdateAsync(insuranceProviders);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveInsuranceProvider")]
        public async Task<IActionResult> get(int id)
        {
            var result = await _insuranceProvidersService.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

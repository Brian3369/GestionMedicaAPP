using GestionMedicaAPP.Domain.Entities.Insurance;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Insurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceProvidersController : ControllerBase
    {
        private readonly IInsuranceProvidersRepository _insuranceProvidersRepository;
        public InsuranceProvidersController(IInsuranceProvidersRepository insuranceProviderRepository)
        {
            _insuranceProvidersRepository = insuranceProviderRepository;
        }

        [HttpGet("GetInsuranceProvider")]
        public async Task<IActionResult> Get()
        {
            var result = await _insuranceProvidersRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetInsuranceProviderById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _insuranceProvidersRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveInsuranceProvider")]
        public async Task<IActionResult> Post([FromBody] InsuranceProviders insuranceProviders)
        {
            var result = await _insuranceProvidersRepository.Save(insuranceProviders);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateInsuranceProvider")]
        public async Task<IActionResult> Put(int id, [FromBody] InsuranceProviders insuranceProviders)
        {
            var result = await _insuranceProvidersRepository.Update(insuranceProviders);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveInsuranceProvider")]
        public async Task<IActionResult> Remove(InsuranceProviders insuranceProviders)
        {
            var result = await _insuranceProvidersRepository.Remove(insuranceProviders);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

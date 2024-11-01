using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Domain.Entities.System;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Persistance.Interfaces.System;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionMedicaAPP.Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordsRepository _medicalRecordsRepository;
        public MedicalRecordsController(IMedicalRecordsRepository medicalRecordsRepository)
        {
            _medicalRecordsRepository = medicalRecordsRepository;
        }

        [HttpGet("GetMedicalRecords")]
        public async Task<IActionResult> Get()
        {
            var result = await _medicalRecordsRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetMedicalRecordsById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _medicalRecordsRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveMedicalRecords")]
        public async Task<IActionResult> Post([FromBody] MedicalRecords medicalRecords)
        {
            var result = await _medicalRecordsRepository.Save(medicalRecords);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateMedicalRecords")]
        public async Task<IActionResult> Put(int id, [FromBody] MedicalRecords medicalRecords)
        {
            var result = await _medicalRecordsRepository.Update(medicalRecords);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveMedicalRecords")]
        public async Task<IActionResult> Remove(MedicalRecords medicalRecords)
        {
            var result = await _medicalRecordsRepository.Remove(medicalRecords);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

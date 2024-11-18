using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
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
        private readonly IMedicalRecordsService _medicalRecordsService;
        public MedicalRecordsController(IMedicalRecordsService medicalRecordsService)
        {
            _medicalRecordsService = medicalRecordsService;
        }

        [HttpGet("GetMedicalRecords")]
        public async Task<IActionResult> Get()
        {
            var result = await _medicalRecordsService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetMedicalRecordsById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _medicalRecordsService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveMedicalRecords")]
        public async Task<IActionResult> Post([FromBody] MedicalRecordsSaveDto medicalRecords)
        {
            var result = await _medicalRecordsService.SaveAsync(medicalRecords);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateMedicalRecords")]
        public async Task<IActionResult> Put([FromBody] MedicalRecordsUpdateDto medicalRecords)
        {
            var result = await _medicalRecordsService.UpdateAsync(medicalRecords);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveMedicalRecords")]
        public async Task<IActionResult> get(int id)
        {
            var result = await _medicalRecordsService.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

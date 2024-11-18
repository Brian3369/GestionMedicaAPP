using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Application.Response.Medical.MedicalRecords;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Persistance.Repositories.Medical;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.Medical
{
    public class MedicalRecordService : IMedicalRecordsService
    {
        private readonly IMedicalRecordsRepository _MedicalRecordsRepository;
        private readonly ILogger<MedicalRecordService> _logger;
        public MedicalRecordService(IMedicalRecordsRepository MedicalRecordssRepository, ILogger<MedicalRecordService> logger)
        {
            _logger = logger;
            _MedicalRecordsRepository = MedicalRecordssRepository;
        }
        public async Task<MedicalRecordsResponse> GetAll()
        {
            MedicalRecordsResponse MedicalRecordssResponse = new MedicalRecordsResponse();

            try
            {
                var result = await _MedicalRecordsRepository.GetAll();

                if (!result.Success)
                {
                    MedicalRecordssResponse.Message = result.Message;
                    MedicalRecordssResponse.IsSuccess = result.Success;
                    return MedicalRecordssResponse;
                }

                MedicalRecordssResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                MedicalRecordssResponse.IsSuccess = false;
                MedicalRecordssResponse.Model = "Error obteniendo el historial medico";
                _logger.LogError(MedicalRecordssResponse.Message, ex.ToString());
            }

            return MedicalRecordssResponse;
        }

        public Task<MedicalRecordsResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecordsResponse> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecordsResponse> SaveAsync(MedicalRecordsSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecordsResponse> UpdateAsync(MedicalRecordsUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

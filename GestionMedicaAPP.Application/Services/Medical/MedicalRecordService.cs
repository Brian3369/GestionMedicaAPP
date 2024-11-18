using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
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
        public Task<MedicalRecordsRepository> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecordsRepository> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecordsRepository> RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecordsRepository> SaveAsync(MedicalRecordsSaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecordsRepository> UpdateAsync(MedicalRecordsUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

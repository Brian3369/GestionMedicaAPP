using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Persistance.Models.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace GestionMedicaAPP.Persistance.Repositories.Medical
{
    public class MedicalRecordsRepository(GestionMedicaContext context, ILogger<MedicalRecordsRepository> logger) : BaseRepository<MedicalRecords>(context), IMedicalRecordsRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<MedicalRecordsRepository> _logger = logger;

        public async override Task<OperationResult> Save(MedicalRecords entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El registro médico no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando el registro médico.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(MedicalRecords entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El registro médico no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el registro médico.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from record in _context.MedicalRecords
                                     select new MedicalRecordsModel()
                                     {
                                         RecordID = record.RecordID,
                                         PatientID = record.PatientID,
                                         DoctorID = record.DoctorID,
                                         Diagnosis = record.Diagnosis,
                                         Treatment = record.Treatment,
                                         DateOfVisit = record.DateOfVisit,
                                         CreatedAt = record.CreatedAt,
                                         UpdatedAt = record.UpdatedAt,
                                     })
                    .AsNoTracking()
                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los registros médicos.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> GetEntityBy(int id)
        {
            OperationResult result = new OperationResult();

            try
            {
                var medicalRecord = await _context.MedicalRecords
                    .AsNoTracking()
                    .FirstOrDefaultAsync(mr => mr.RecordID == id);

                if (medicalRecord == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el registro médico.";
                    return result;
                }

                result.Data = medicalRecord;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo el registro médico.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
using GestionMedicaAPP.Domain.Entities.users;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.users;
using GestionMedicaAPP.Persistance.Models.users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.users
{
    public sealed class PatientsRepository(GestionMedicaContext context, ILogger<PatientsRepository> logger) : BaseRepository<Patients>(context), IPatientsRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<PatientsRepository> _logger = logger;

        public async override Task<OperationResult> Save(Patients entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El paciente no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando el paciente.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(Patients entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El paciente no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el paciente.";
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
                result.Data = await (from Patients in _context.Patients
                                     select new PatientsModel()
                                     {
                                         PatientID = Patients.PatientID,
                                         DateOfBirth = Patients.DateOfBirth,
                                         Gender = Patients.Gender,
                                         PhoneNumber = Patients.PhoneNumber,
                                         Address = Patients.Address,
                                         EmergencyContactName = Patients.EmergencyContactName,
                                         EmergencyContactPhone = Patients.EmergencyContactPhone,
                                         BloodType = Patients.BloodType,
                                         Allergies = Patients.Allergies,
                                         InsuranceProviderID = Patients.InsuranceProviderID,
                                         CreatedAt = Patients.CreatedAt,
                                         UpdatedAt = Patients.UpdatedAt,
                                         IsActive = Patients.IsActive
                                     })
                    .AsNoTracking()
                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los pacientes.";
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
                var patient = await (from Patients in _context.Patients
                                    where Patients.PatientID == id
                                    select new PatientsModel()
                                    {
                                        PatientID = Patients.PatientID,
                                        DateOfBirth = Patients.DateOfBirth,
                                        Gender = Patients.Gender,
                                        PhoneNumber = Patients.PhoneNumber,
                                        Address = Patients.Address,
                                        EmergencyContactName = Patients.EmergencyContactName,
                                        EmergencyContactPhone = Patients.EmergencyContactPhone,
                                        BloodType = Patients.BloodType,
                                        Allergies = Patients.Allergies,
                                        InsuranceProviderID = Patients.InsuranceProviderID,
                                        CreatedAt = Patients.CreatedAt,
                                        UpdatedAt = Patients.UpdatedAt,
                                        IsActive = Patients.IsActive
                                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (patient == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el pasiente.";
                    return result;
                }

                result.Data = patient;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo el paciente.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
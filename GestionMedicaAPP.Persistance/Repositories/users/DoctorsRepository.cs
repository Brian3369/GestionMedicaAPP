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
    public class DoctorsRepository(GestionMedicaContext context, ILogger<DoctorsRepository> logger) : BaseRepository<Doctors>(context), IDoctorsRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<DoctorsRepository> _logger = logger;

        public async override Task<OperationResult> Save(Doctors entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El doctor no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando el doctor.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(Doctors entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El doctor no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el doctor.";
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
                result.Data = await (from Doctors in _context.Doctors
                                     where Doctors.IsActive == true
                                     select new DoctorsModel()
                                     {
                                         DoctorID = Doctors.DoctorID,
                                         SpecialtyID = Doctors.SpecialtyID,
                                         licenseNumber = Doctors.licenseNumber,
                                         PhoneNumber = Doctors.PhoneNumber,
                                         YearsOfExperience = Doctors.YearsOfExperience,
                                         Education = Doctors.Education,
                                         Bio = Doctors.Bio,
                                         ConsultationFee = Doctors.ConsultationFee,
                                         ClinicAddress = Doctors.ClinicAddress,
                                         AvailabilityModeId = Doctors.AvailabilityModeId,
                                         LicenseExpirationDate = Doctors.LicenseExpirationDate,
                                         CreatedAt = Doctors.CreatedAt,
                                         UpdatedAt = Doctors.UpdatedAt,
                                         IsActive = Doctors.IsActive
                                     })
                    .AsNoTracking()
                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los doctores.";
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
                var doctor = await (from Doctors in _context.Doctors
                                     where Doctors.DoctorID == id
                                     select new DoctorsModel()
                                     {
                                         DoctorID = Doctors.DoctorID,
                                         SpecialtyID = Doctors.SpecialtyID,
                                         licenseNumber = Doctors.licenseNumber,
                                         PhoneNumber = Doctors.PhoneNumber,
                                         YearsOfExperience = Doctors.YearsOfExperience,
                                         Education = Doctors.Education,
                                         Bio = Doctors.Bio,
                                         ConsultationFee = Doctors.ConsultationFee,
                                         ClinicAddress = Doctors.ClinicAddress,
                                         AvailabilityModeId = Doctors.AvailabilityModeId,
                                         LicenseExpirationDate = Doctors.LicenseExpirationDate,
                                         CreatedAt = Doctors.CreatedAt,
                                         UpdatedAt = Doctors.UpdatedAt,
                                         IsActive = Doctors.IsActive
                                     })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (doctor == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el doctor.";
                    return result;
                }

                result.Data = doctor;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo el doctor.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
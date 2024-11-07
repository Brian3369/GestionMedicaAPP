using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using GestionMedicaAPP.Persistance.Models.appointmets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.appointments
{
    public class DoctorAvailabilityRepository(GestionMedicaContext Context, ILogger<DoctorAvailabilityRepository> logger) : BaseRepository<DoctorAvailability>(Context), IDoctorAvailabilityRepository
    {
        private readonly GestionMedicaContext _context = Context;
        private readonly ILogger<DoctorAvailabilityRepository> _logger = logger;

        public async override Task<OperationResult> Save(DoctorAvailability entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La disponibilidad del doctor no puede ser nula.";
                return result;
            }

            if (entity.AvailableDate == default)
            {
                result.Success = false;
                result.Message = "La fecha de disponibilidad es requerida.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando la disponibilidad del doctor.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(DoctorAvailability entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La disponibilidad del doctor no puede ser nula.";
                return result;
            }

            if (entity.AvailableDate == default)
            {
                result.Success = false;
                result.Message = "La fecha de disponibilidad es requerida.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando la disponibilidad del doctor.";
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
                result.Data = await (from doctorAvailability in _context.DoctorAvailability
                                     select new DoctorAvailabilityModel()
                                     {
                                         AvailabilityID = doctorAvailability.AvailabilityID,
                                         DoctorID = doctorAvailability.DoctorID,
                                         AvailableDate = doctorAvailability.AvailableDate,
                                         StartTime = doctorAvailability.StartTime,
                                         EndTime = doctorAvailability.EndTime
                                     }).AsNoTracking()
                                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo las disponibilidades del doctor.";
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
                var availability = await (from d in _context.DoctorAvailability
                                          where d.AvailabilityID == id
                                          select new DoctorAvailabilityModel()
                                          {
                                              AvailabilityID = d.AvailabilityID,
                                              DoctorID = d.DoctorID,
                                              AvailableDate = d.AvailableDate,
                                              StartTime = d.StartTime,
                                              EndTime = d.EndTime
                                          })
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync();

                if (availability == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró la disponibilidad del doctor.";
                    return result;
                }

                result.Data = availability;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo la disponibilidad del doctor.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
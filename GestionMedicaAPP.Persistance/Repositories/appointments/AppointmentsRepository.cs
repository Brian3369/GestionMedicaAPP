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
    public class AppointmentsRepository(GestionMedicaContext Context, ILogger<AppointmentsRepository> logger) : BaseRepository<Appointments>(Context), IAppointmentsRepository
    {
        private readonly GestionMedicaContext _context = Context;
        private readonly ILogger<AppointmentsRepository> _logger = logger;

        public async override Task<OperationResult> Save(Appointments entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La cita no puede ser nula.";
                return result;
            }

            if (entity.AppointmentDate == default)
            {
                result.Success = false;
                result.Message = "La fecha de la cita es requerida.";
                return result;
            }

            if (await base.Exists(a => a.DoctorID == entity.DoctorID && a.PatientID == entity.PatientID && a.AppointmentDate == entity.AppointmentDate))
            {
                result.Success = false;
                result.Message = "Ya existe una cita programada para este paciente y doctor en esa fecha.";
                return result;
            }

            try
            {
                result.Success = true;
                result = await base.Save(entity);
                result.Message = "Cita guardada correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando la cita.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(Appointments entity)
        {
            OperationResult result = new OperationResult();
            var AppointmentsToUpdate = await _context.Appointments.FindAsync(entity.AppointmentID);

            if (AppointmentsToUpdate == null)
            {
                result.Success = false;
                result.Message = "La cita no existe.";
                return result;
            }

            if (entity.StatusID == null)
            {
                result.Success = false;
                result.Message = "El estatus es requerido.";
                return result;
            }

            if (entity.DoctorID == null || entity.PatientID == null || entity.StatusID == null || entity.AppointmentDate == null)
            {
                result.Success = false;
                result.Message = "Debe llenar todos los datos";
                return result;
            }

            try
            {
                AppointmentsToUpdate.AppointmentID = entity.AppointmentID;
                AppointmentsToUpdate.PatientID = entity.PatientID;
                AppointmentsToUpdate.DoctorID = entity.DoctorID;
                AppointmentsToUpdate.AppointmentDate = entity.AppointmentDate;
                AppointmentsToUpdate.StatusID = entity.StatusID;
                AppointmentsToUpdate.UpdatedAt = entity.UpdatedAt;
                AppointmentsToUpdate.CreatedAt = entity.CreatedAt;

                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "Cita actualizada correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando cita.";
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

                result.Data = await (from Appointments in _context.Appointments
                                     where Appointments.StatusID == 1
                                     select new AppointmentsModel()
                                     {
                                         AppointmentID = Appointments.AppointmentID,
                                         PatientID = Appointments.PatientID,
                                         DoctorID = Appointments.DoctorID,
                                         AppointmentDate = Appointments.AppointmentDate,
                                         StatusID = Appointments.StatusID,
                                         CreatedAt = Appointments.CreatedAt,
                                         UpdatedAt = Appointments.UpdatedAt,
                                     }).AsNoTracking()
                                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo las citas.";
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
                var appointment = await (from a in _context.Appointments
                                         where a.AppointmentID == id
                                         select new AppointmentsModel()
                                         {
                                             AppointmentID = a.AppointmentID,
                                             PatientID = a.PatientID,
                                             DoctorID = a.DoctorID,
                                             AppointmentDate = a.AppointmentDate,
                                             StatusID = a.StatusID,
                                             CreatedAt = a.CreatedAt,
                                             UpdatedAt = a.UpdatedAt
                                         })
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

                if (appointment == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró la cita.";
                    return result;
                }

                result.Data = appointment;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo la cita.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}

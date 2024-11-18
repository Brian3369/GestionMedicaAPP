using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Application.Response.Appointments.Appointments;
using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.appointments
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IAppointmentsRepository _appointmentsRepository;
        private readonly ILogger<AppointmentsService> _logger;

        public AppointmentsService(IAppointmentsRepository appointmentsRepository, ILogger<AppointmentsService> logger) 
        {
            if (appointmentsRepository is null)
            {
                throw new ArgumentNullException(nameof(appointmentsRepository));
            }
            _appointmentsRepository = appointmentsRepository;
        }    
        public async Task<AppointmentsResponse> GetAll()
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var result = await _appointmentsRepository.GetAll();

                if (!result.Success)
                {
                    appointmentsResponse.Message = result.Message;
                    appointmentsResponse.IsSuccess = result.Success;
                    return appointmentsResponse;
                }

                appointmentsResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Model = "Error obteniendo las citas";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }

            return appointmentsResponse;
        }

        public async Task<AppointmentsResponse> GetById(int Id)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var result = await _appointmentsRepository.GetEntityBy(Id);

                if (!result.Success)
                {
                    appointmentsResponse.Message = result.Message;
                    appointmentsResponse.IsSuccess = result.Success;
                    return appointmentsResponse;
                }

                appointmentsResponse.Model = result.Data;
                appointmentsResponse.IsSuccess = result.Success;
            }

            catch (Exception ex)
            {

                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Model = "Error obteniendo las citas";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }

            return appointmentsResponse;
        }

        public async Task<AppointmentsResponse> RemoveById(int id)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var resultEntity = await _appointmentsRepository.GetEntityBy(id);

                if (!resultEntity.Success)
                {
                    appointmentsResponse.IsSuccess = resultEntity.Success;
                    appointmentsResponse.Message = resultEntity.Message;
                    return appointmentsResponse;
                }

                var data = resultEntity.Data;

                Appointments appointments = new Appointments
                {
                    AppointmentID = data.AppointmentID,
                    PatientID = data.PatientID,
                    DoctorID = data.DoctorID,
                    AppointmentDate = data.AppointmentDate,
                    StatusID = data.StatusID,
                    CreatedAt = data.CreatedAt,
                    UpdatedAt = data.UpdatedAt,
                };

                var deleteResult = await _appointmentsRepository.Remove(appointments);

                appointmentsResponse.IsSuccess = deleteResult.Success;
                appointmentsResponse.Message = deleteResult.Message;
            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Message = "Error eliminando la cita.";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }

            return appointmentsResponse;
        }

        public async Task<AppointmentsResponse> SaveAsync(AppointmentsSaveDto dto)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();
            if (dto == null)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Message = "La ciata no puede ser nulo.";
                return appointmentsResponse;
            }
            try
            {
                Appointments appointments = new Appointments();

                appointments.PatientID = dto.PatientID;
                appointments.DoctorID = dto.DoctorID;
                appointments.AppointmentDate = dto.AppointmentDate;
                appointments.StatusID = dto.StatusID;
                appointments.CreatedAt = dto.CreatedAt;
                appointments.UpdatedAt = dto.UpdatedAt;


                var result = await _appointmentsRepository.Save(appointments);
                result.Message = "La cita fue creada correctamente.";
            }

            catch (Exception ex)
            {

                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Model = "Error guardando las citas";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }

            return appointmentsResponse;
        }

        public async Task<AppointmentsResponse> UpdateAsync(AppointmentsUpdateDto dto)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var resultEntity = await _appointmentsRepository.GetEntityBy(dto.AppointmentID);

                if (!resultEntity.Success)
                {
                    appointmentsResponse.IsSuccess = resultEntity.Success;
                    appointmentsResponse.Message = resultEntity.Message;
                    return appointmentsResponse;
                }

                var data = resultEntity.Data;
                if (data == null)
                {
                    appointmentsResponse.IsSuccess = false;
                    appointmentsResponse.Message = "Los datos del usuario no están disponibles.";
                    return appointmentsResponse;
                }

                Appointments appointments = data as Appointments ?? new Appointments
                {
                    AppointmentID = (int)(data.GetType().GetProperty("AppointmentID")?.GetValue(data) ?? 0),
                    PatientID = (int)(data.GetType().GetProperty("PatientID")?.GetValue(data) ?? 0),
                    DoctorID = (int)(data.GetType().GetProperty("DoctorID")?.GetValue(data) ?? 0),
                    AppointmentDate = (DateTime)(data.GetType().GetProperty("AppointmentDate")?.GetValue(data) ?? DateTime.MinValue),
                    StatusID = (int)(data.GetType().GetProperty("StatusID")?.GetValue(data) ?? 0),
                    CreatedAt = (DateTime)(data.GetType().GetProperty("CreatedAt")?.GetValue(data) ?? DateTime.MinValue),
                    UpdatedAt = (DateTime)(data.GetType().GetProperty("UpdatedAt")?.GetValue(data) ?? DateTime.MinValue),
                };

                appointments.AppointmentID = dto.AppointmentID;
                appointments.PatientID = dto.PatientID;
                appointments.DoctorID = dto.DoctorID;
                appointments.AppointmentDate = dto.AppointmentDate;
                appointments.StatusID = dto.StatusID;
                appointments.UpdatedAt = dto.UpdatedAt;
                appointments.CreatedAt = dto.CreatedAt;

                var result = await _appointmentsRepository.Update(appointments);
                appointmentsResponse.IsSuccess = result.Success;
                appointmentsResponse.Message = result.Success ? "Usuario actualizado con éxito." : "Error al actualizar el usuario.";
            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Message = "Error actualizando el usuario.";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }

            return appointmentsResponse;
        }
    }
}

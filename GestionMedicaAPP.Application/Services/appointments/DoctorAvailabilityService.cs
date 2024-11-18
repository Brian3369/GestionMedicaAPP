using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Application.Response.Appointments.Appointments;
using GestionMedicaAPP.Application.Response.Appointments.DoctorAvailability;
using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Application.Services.appointments
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
        private readonly ILogger<DoctorAvailabilityService> _logger;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository doctorAvailabilityRepository, ILogger<DoctorAvailabilityService> logger)
        {
            _logger = logger;
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
        }
        public async Task<DoctorAvailabilityResponse> GetAll()
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                var result = await _doctorAvailabilityRepository.GetAll();

                if (!result.Success)
                {
                    doctorAvailabilityResponse.Message = result.Message;
                    doctorAvailabilityResponse.IsSuccess = result.Success;
                    return doctorAvailabilityResponse;
                }

                doctorAvailabilityResponse.Model = result.Data;
            }

            catch (Exception ex)
            {

                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Model = "Error obteniendo las citas";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }

            return doctorAvailabilityResponse;
        }

        public async Task<DoctorAvailabilityResponse> GetById(int Id)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                var result = await _doctorAvailabilityRepository.GetEntityBy(Id);

                if (!result.Success)
                {
                    doctorAvailabilityResponse.Message = result.Message;
                    doctorAvailabilityResponse.IsSuccess = result.Success;
                    return doctorAvailabilityResponse;
                }

                doctorAvailabilityResponse.Model = result.Data;
                doctorAvailabilityResponse.IsSuccess = result.Success;
            }

            catch (Exception ex)
            {

                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Model = "Error obteniendo las citas";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }

            return doctorAvailabilityResponse;
        }

        public async Task<DoctorAvailabilityResponse> RemoveById(int id)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                var resultEntity = await _doctorAvailabilityRepository.GetEntityBy(id);

                if (!resultEntity.Success)
                {
                    doctorAvailabilityResponse.IsSuccess = resultEntity.Success;
                    doctorAvailabilityResponse.Message = resultEntity.Message;
                    return doctorAvailabilityResponse;
                }

                var data = resultEntity.Data;

                DoctorAvailability doctorAvailability = new DoctorAvailability
                {
                    AvailabilityID = data.AvailabilityID,
                    DoctorID = data.DoctorID,
                    AvailableDate = data.AvailableDate,
                    StartTime = data.StartTime,
                    EndTime = data.EndTime,
                };

                var deleteResult = await _doctorAvailabilityRepository.Remove(doctorAvailability);

                doctorAvailabilityResponse.IsSuccess = deleteResult.Success;
                doctorAvailabilityResponse.Message = deleteResult.Message;
            }
            catch (Exception ex)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Message = "Error eliminando el modo.";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }

            return doctorAvailabilityResponse;
        }

        public async Task<DoctorAvailabilityResponse> SaveAsync(DoctorAvailabilitySaveDto dto)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            if (dto == null)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Message = "La ciata no puede ser nulo.";
                return doctorAvailabilityResponse;
            }
            try
            {
                DoctorAvailability doctorAvailability = new DoctorAvailability();

                doctorAvailability.AvailabilityID = dto.AvailabilityID;
                doctorAvailability.DoctorID = dto.DoctorID;
                doctorAvailability.AvailableDate = dto.AvailableDate;
                doctorAvailability.StartTime = dto.StartTime;
                doctorAvailability.EndTime = dto.EndTime;


                var result = await _doctorAvailabilityRepository.Save(doctorAvailability);
                result.Message = "Availability creado correctamente.";
            }

            catch (Exception ex)
            {

                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Model = "Error guardando las citas";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }

            return doctorAvailabilityResponse;
        }

        public async Task<DoctorAvailabilityResponse> UpdateAsync(DoctorAvailabilityUpdateDto dto)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                var resultEntity = await _doctorAvailabilityRepository.GetEntityBy(dto.AvailabilityID);

                if (!resultEntity.Success)
                {
                    doctorAvailabilityResponse.IsSuccess = resultEntity.Success;
                    doctorAvailabilityResponse.Message = resultEntity.Message;
                    return doctorAvailabilityResponse;
                }

                var data = resultEntity.Data;
                if (data == null)
                {
                    doctorAvailabilityResponse.IsSuccess = false;
                    doctorAvailabilityResponse.Message = "Los datos de disponibilidad no están disponibles.";
                    return doctorAvailabilityResponse;
                }

                DoctorAvailability doctorAvailability = data as DoctorAvailability ?? new DoctorAvailability
                {
                    AvailabilityID = (int)(data.GetType().GetProperty("AvailabilityID")?.GetValue(data) ?? 0),
                    DoctorID = (int)(data.GetType().GetProperty("DoctorID")?.GetValue(data) ?? 0),
                    AvailableDate = (DateTime)(data.GetType().GetProperty("AvailableDate")?.GetValue(data) ?? DateTime.MinValue),
                    StartTime = (TimeSpan)(data.GetType().GetProperty("StartTime")?.GetValue(data) ?? TimeSpan.MinValue),
                    EndTime = (TimeSpan)(data.GetType().GetProperty("EndTime")?.GetValue(data) ?? TimeSpan.MinValue),
                };

                doctorAvailability.AvailabilityID = dto.AvailabilityID;
                doctorAvailability.DoctorID = dto.DoctorID;
                doctorAvailability.AvailableDate = dto.AvailableDate;
                doctorAvailability.StartTime = dto.StartTime;
                doctorAvailability.EndTime = dto.EndTime;

                var result = await _doctorAvailabilityRepository.Update(doctorAvailability);
                doctorAvailabilityResponse.IsSuccess = result.Success;
                doctorAvailabilityResponse.Message = result.Success ? "Available actualizado con éxito." : "Error al actualizar el doctorAvailability.";
            }
            catch (Exception ex)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Message = "Error actualizando el doctorAvailability.";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }

            return doctorAvailabilityResponse;
        }
    }
}

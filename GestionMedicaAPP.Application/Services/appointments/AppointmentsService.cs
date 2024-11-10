using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Application.Response.Appointments.Appointments;
using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Domain.Entities.users;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

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

                List<GetAppointmentsDto> appointments = ((List<Appointments>)result.Data)
                                                   .Select(appointments => new GetAppointmentsDto() 
                                                   {
                                                       AppointmentID = appointments.AppointmentID,
                                                       PatientID = appointments.PatientID,
                                                       DoctorID = appointments.DoctorID,
                                                       AppointmentDate = appointments.AppointmentDate
                                                   }).ToList();

                appointmentsResponse.IsSuccess = result.Success;
                appointmentsResponse.Model = result;
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

                Appointments appointments = (Appointments)result.Data;

                GetAppointmentsDto getAppointmentsDto = new GetAppointmentsDto()
                {
                    AppointmentID = appointments.AppointmentID,
                    PatientID = appointments.PatientID,
                    DoctorID = appointments.DoctorID,
                    AppointmentDate = appointments.AppointmentDate
                };

                appointmentsResponse.IsSuccess = result.Success;
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

        public async Task<AppointmentsResponse> SaveAsync(AppointmentsSaveDto dto)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                Appointments appointments = new Appointments();

                appointments.PatientID = dto.PatientID;
                appointments.DoctorID = dto.DoctorID;
                appointments.AppointmentDate = dto.AppointmentDate;
                appointments.CreatedAt = dto.CreatedAt;
                appointments.UpdatedAt = dto.UpdatedAt;

                var result = await _appointmentsRepository.Save(appointments);
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
                
                Appointments appointmentsToUpdate = (Appointments)resultEntity.Data;


                appointmentsToUpdate.PatientID = dto.PatientID;
                appointmentsToUpdate.DoctorID = dto.DoctorID;
                appointmentsToUpdate.AppointmentDate = dto.AppointmentDate;
                appointmentsToUpdate.UpdatedAt = dto.UpdatedAt;

                var result = await _appointmentsRepository.Update(appointmentsToUpdate);
            }

            catch (Exception ex)
            {

                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Model = "Error actualizando las citas";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }

            return appointmentsResponse;
        }
    }
}

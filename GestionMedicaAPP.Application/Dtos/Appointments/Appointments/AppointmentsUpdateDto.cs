namespace GestionMedicaAPP.Application.Dtos.Appointments.Appointments
{
    public class AppointmentsUpdateDto : AppointmentsBaseDto
    {
        public int AppointmentID { get; set; }
        public int StatusID { get; set; }
    }
}

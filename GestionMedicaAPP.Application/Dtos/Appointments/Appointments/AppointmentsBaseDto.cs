namespace GestionMedicaAPP.Application.Dtos.Appointments.Appointments
{
    public class AppointmentsBaseDto
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int StatusID { get; set; }
    }
}

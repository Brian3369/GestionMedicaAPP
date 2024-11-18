namespace GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability
{
    public class DoctorAvailabilityBaseDto
    {
        public int AvailabilityID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AvailableDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int StatusID { get; set; }
    }
}

namespace GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability
{
    public class GetDoctorAvailabilityDto : DoctorAvailabilityBaseDto
    {
        public int AvailabilityID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AvailableDate { get; set; }
        public int StatusID { get; set; }
    }
}

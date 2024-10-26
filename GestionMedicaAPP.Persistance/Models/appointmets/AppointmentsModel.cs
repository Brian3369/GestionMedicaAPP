using System.ComponentModel.DataAnnotations;

namespace GestionMedicaAPP.Domain.Entities.appointmets
{
    public sealed class AppointmentsModel
    {
        [Key]
        public int AppointmentsID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int StatusID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}

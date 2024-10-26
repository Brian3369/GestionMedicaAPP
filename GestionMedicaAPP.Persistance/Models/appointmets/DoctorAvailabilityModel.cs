using System.ComponentModel.DataAnnotations;

namespace GestionMedicaAPP.Domain.Entities.appointmets
{
    public sealed class DoctorAvailabilityModel
    {
        [Key]
        public int AvailabilityID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AvalitableDate { get; set; }
        public TimeSpan StarTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}

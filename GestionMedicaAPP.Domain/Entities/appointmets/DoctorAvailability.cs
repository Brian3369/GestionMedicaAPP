using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GestionMedicaAPP.Domain.Entities.appointmets
{
    [Table("DoctorAvailability", Schema = "appointments")]
    public class DoctorAvailability
    {
        [Key]
        public int AvailabilityID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AvalitableDate { get; set; }
        public TimeSpan StarTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}

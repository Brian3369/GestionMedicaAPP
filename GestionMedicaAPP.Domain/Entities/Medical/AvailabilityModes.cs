using GestionMedicaAPP.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionMedicaAPP.Domain.Entities.Medical
{
    [Table("AvailabilityModes", Schema = "medical")]
    public class AvailabilityModes : BaseEntity
    {
        [Key]
        public int AvailabilityModelID { get; set; }
        public string AvailabilityMode { get; set; }
    }
}

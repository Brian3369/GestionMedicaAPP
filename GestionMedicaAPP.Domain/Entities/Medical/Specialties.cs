using GestionMedicaAPP.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionMedicaAPP.Domain.Entities.Medical
{
    [Table("Specialties", Schema = "medical")]

    public class Specialties : BaseEntity
    {
        [Key]
        public int SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
    }
}

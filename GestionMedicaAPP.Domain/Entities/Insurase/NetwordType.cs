using GestionMedicaAPP.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionMedicaAPP.Domain.Entities.Insurase
{
    [Table("NetwordType", Schema = "insuranse")]
    public class NetwordType : BaseEntity
    {
        [Key]
        public int NetworkTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

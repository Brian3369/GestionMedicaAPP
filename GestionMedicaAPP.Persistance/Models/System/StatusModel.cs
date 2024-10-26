using System.ComponentModel.DataAnnotations;

namespace GestionMedicaAPP.Persistance.Models.System
{
    public sealed class StatusModel
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }
}

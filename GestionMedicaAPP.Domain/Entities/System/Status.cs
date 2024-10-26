using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedicaAPP.Domain.Entities.System
{
    [Table("Status", Schema = "system")]
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedicaAPP.Domain.Entities.users
{
    [Table("Permission", Schema = "users")]

    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
    }
}

﻿using GestionMedicaAPP.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionMedicaAPP.Domain.Entities.users
{
    [Table("Users", Schema = "users")]

    public class Users : BaseEntity
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleID { get; set; }
    }
}

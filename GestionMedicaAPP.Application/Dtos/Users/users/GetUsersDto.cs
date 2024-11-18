namespace GestionMedicaAPP.Application.Dtos.Users.users
{
    public class GetUsersDto
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleID { get; set; }
        public bool IsActive { get; set; }

    }
}

namespace GestionMedicaAPP.Application.Dtos.Users
{
    public class UsersBaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleID { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}

namespace GestionMedicaAPP.Application.Dtos.Users.users
{
    public class UsersUpdateDto : UsersBaseDto
    {
        public int UserID { get; set; }
        public bool IsActive { get; set; }
    }
}

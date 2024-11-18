namespace GestionMedicaAPP.Application.Dtos.Users
{
    public class UsersUpdateDto : UsersBaseDto
    {
        public int UserID { get; set; }
        public bool IsActive { get; set; }
    }
}

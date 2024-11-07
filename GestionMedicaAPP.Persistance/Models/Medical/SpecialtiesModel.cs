namespace GestionMedicaAPP.Persistance.Models.Medical
{
    public sealed class SpecialtiesModel
    {
        public short SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}

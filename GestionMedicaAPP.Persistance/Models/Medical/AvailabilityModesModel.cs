namespace GestionMedicaAPP.Persistance.Models.Medical
{
    public sealed class AvailabilityModesModel
    {
        public int SAvailabilityModeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

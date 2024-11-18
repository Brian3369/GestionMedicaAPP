namespace GestionMedicaAPP.Application.Dtos.Insurance.NetworkType
{
    public class GetNetworkTypeDto
    {
        public int NetworkTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}

namespace GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords
{
    public class GetMedicalRecordsDto
    {
        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime RecordDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Notes { get; set; }
        public int StatusID { get; set; }
    }
}

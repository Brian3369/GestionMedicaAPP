﻿namespace GestionMedicaAPP.Application.Dtos.Users.Patients
{
    public class GetPatientsDto
    {
        public int PatientID { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public int InsuranceProviderID { get; set; }
        public bool IsActive { get; set; }
    }
}

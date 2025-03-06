namespace HospitalSystem.Application.DTOs.PatientDTOs
{
    public class AddPatientDTO
    {
        public string? InsuranceNumber { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string EmergencyContact { get; set; }
        public string PersonId { get; set; }
    }
}

using HospitalSystem.Domain.Enums;

namespace HospitalSystem.Application.DTOs.PatientDTOs
{
    public class PatientReadDTO
    {
        // Person
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public BloodType? BloodType { get; set; }
        public Gender Gender { get; set; }

        // Patient
        public int PatientId { get; set; }
        public string? InsuranceNumber { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime? LastVisitDate { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public string EmergencyContact { get; set; }
    }
}

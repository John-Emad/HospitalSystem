using HospitalSystem.Domain.Enums;
using System.Reflection.Metadata;

namespace HospitalSystem.Application.DTOs.PatientDTOs
{
    public class PatientRegisterDTO
    {
        // Person
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public BloodType? BloodType { get; set; }
        public Gender Gender { get; set; }

        // Patient
        public string? InsuranceNumber { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string EmergencyContact { get; set; }

    }
}

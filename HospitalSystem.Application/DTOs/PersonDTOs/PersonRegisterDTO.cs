using HospitalSystem.Domain.Enums;

namespace HospitalSystem.Application.DTOs
{
    public class PersonRegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public BloodType? BloodType { get; set; }
        public Gender Gender { get; set; }
    }
}

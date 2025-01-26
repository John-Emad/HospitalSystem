using HospitalSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities.persons
{
    public class Person : IdentityUser
    {
        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public required string FirstName { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public required string LastName { get; set; }

        [PersonalData]
        [Required]
        public DateTime BirthDate { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string? Address { get; set; }

        [PersonalData]
        [Column("Blood Type")]
        public BloodType? BloodType { get; set; }

        [PersonalData]
        public Gender Gender { get; set; }

        [Column("User role")]
        public UserType UserType { get; set; }

        // public UserType UserType { get; set; } CRUD operations will be more complex




    }
}

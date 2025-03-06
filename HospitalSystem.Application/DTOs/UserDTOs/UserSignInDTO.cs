using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Application.DTOs.UserDTOs
{
    public class UserSignInDTO
    {
        [EmailAddress]
        [Required]
        public required string Email { get; set; }

        [PersonalData]
        [Required]
        public required string Password { get; set; }
    }
}

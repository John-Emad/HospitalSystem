﻿using HospitalSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Domain.Entities
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

        // [PersonalData]
        // [Column(TypeName = "nvarchar(3)")]
        // public BloodTypeClass? BloodType { get; set; }



        public Gender Gender {  get; set; }

        // public UserType UserType { get; set; } CRUD operations will be more complex




    }
}

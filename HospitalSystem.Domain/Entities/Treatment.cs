﻿using HospitalSystem.Domain.Entities.People;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public DateTime TreatmentDate{ get; set; } = DateTime.Now;

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; } 

        [Required]
        [DataType(DataType.Currency)]
        public Decimal TreatmentCost { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }


    }
}

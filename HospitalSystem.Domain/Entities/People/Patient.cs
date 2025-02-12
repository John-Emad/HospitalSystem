using HospitalSystem.Domain.Entities.persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Domain.Entities.People
{
    public class Patient:Person
    {
        [Required]
        [StringLength(50)]
        public required string MedicalRecordNumber { get; set; }

        public string? InsuranceNumber { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public DateTime LastVisitDate { get; set; }
        [Required]
        public DateTime NextVisitDate { get; set; }
        [Required]
        public string EmergencyContact { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
        public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<PatientAdmission> PatientAdmissions { get; set; } = new List<PatientAdmission>();


    }
}

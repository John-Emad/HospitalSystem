using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Domain.Entities.People
{
    public class Patient 
    {
        [Key]
        public int PatientId { get; set; }

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

        public virtual ICollection<Person> People { get; set; } = new List<Person>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
        public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<PatientAdmission> PatientAdmissions { get; set; } = new List<PatientAdmission>();
        public virtual ICollection<PatientBill> PatientBills { get; set; } = new List<PatientBill>();


    }
}

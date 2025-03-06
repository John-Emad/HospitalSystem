using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Domain.Entities.People
{
    public class Patient 
    {
        [Key]
        public int PatientId { get; set; }
        public string? InsuranceNumber { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime? LastVisitDate { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public string EmergencyContact { get; set; }
        public string PersonId{ get; set; }

        // public virtual ICollection<Person> People { get; set; } = new List<Person>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
        public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<PatientAdmission> PatientAdmissions { get; set; } = new List<PatientAdmission>();
        public virtual ICollection<PatientBill> PatientBills { get; set; } = new List<PatientBill>();


    }
}

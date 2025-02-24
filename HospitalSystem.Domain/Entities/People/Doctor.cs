using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.Domain.Entities.People
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        public int MedicalSpecialityId { get; set; }
        public required string Schedule { get; set; }

        [DataType(DataType.Currency)]
        public required decimal VisitPrice { get; set; }

        [DataType(DataType.Currency)]
        public required decimal FollowUpPrice { get; set; }

        [DataType(DataType.Currency)]
        public required decimal ImpatientVisitPrice { get; set; }

        public virtual MedicalSpeciality MedicalSpeciality { get; set; }
        public virtual ICollection<Person> People { get; set; } = new List<Person>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
        public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();

        public virtual ICollection<PatientAdmission> PatientAdmissions { get; set; } = new List<PatientAdmission>();

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();



    }
}

using HospitalSystem.Domain.Entities.People;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Domain.Entities
{
    public class PatientAdmission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; } = DateTime.Now;

        public DateTime DischargeDate { get; set; }

        [Required]
        public int BedNumber { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public Decimal Cost { get; set; }

        public virtual Patient Patient { get; set; }  // Navigation property to Patient
        public virtual Doctor Doctor { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }


    }

}

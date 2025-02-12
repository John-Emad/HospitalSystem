using HospitalSystem.Domain.Entities.People;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities
{
    public class PatientAdmission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Patient Id")]
        public int PatientId { get; set; }

        [Required]
        [Column(TypeName = "Doctor Id")]
        public int DoctorId { get; set; }

        [Required]
        [Column(TypeName = "Admission Date")]
        public DateTime AdmissionDate { get; set; } = DateTime.Now;

        [Column(TypeName = "Discharge Date")]
        public DateTime DischargeDate { get; set; }

        [Required]
        [Column(TypeName = "Bed Number")]
        public int BedNumber { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public Decimal Cost { get; set; }

        public virtual Patient Patient { get; set; }  // Navigation property to Patient
        public virtual Doctor Doctor { get; set; }

        public virtual MedicalRecord MedicalRecord { get; set; }


    }

}

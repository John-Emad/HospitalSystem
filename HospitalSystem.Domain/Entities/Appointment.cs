using HospitalSystem.Domain.Entities.People;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        [Column("Appointment Date")]
        public DateTime AppointmentDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }
        
        public bool IsDone { get; set; }

        public virtual Patient Patient { get; set; }  // Navigation property to Patient
        public virtual Doctor Doctor { get; set; } 
        public virtual Treatment Treatment { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }


    }
}

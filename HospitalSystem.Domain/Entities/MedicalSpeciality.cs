using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HospitalSystem.Domain.Entities.People;

namespace HospitalSystem.Domain.Entities
{
    public class MedicalSpeciality
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();


    }
}

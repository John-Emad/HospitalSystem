using HospitalSystem.Domain.Entities.People;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities
{
    public class PatientBill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? InsuranceInfo { get; set; }

        [Required]
        [Column("Bill Date")]
        public DateTime BillDate { get; set; } = DateTime.Now;

        [Required]
        [Column("Is Payed")]
        public  bool IsPayed { get; set; } = false;

        public virtual Patient Patient { get; set; }
    }
}

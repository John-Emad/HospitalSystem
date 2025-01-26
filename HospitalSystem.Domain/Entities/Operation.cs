using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Domain.Entities
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        [Column("Operation Date")]
        public DateTime OperationDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }
        public bool IsDone { get; set; }
    }
}

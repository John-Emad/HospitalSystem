using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Column(TypeName = "nvarchar(70)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Required]
        [RegularExpression("^[0 - 9]+$")]
        [Column("Contact Number", TypeName = "nvarchar(50)")]
        public string ContactNumber { get; set; }

        [Required]
        [RegularExpression("^[0 - 9]+$")]
        [Column("Emergency Number", TypeName = "nvarchar(50)")]
        public string EmergencyNumber { get; set; }

        public List<Department> Departments { get; set; }

    }
}

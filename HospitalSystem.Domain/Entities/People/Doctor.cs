using HospitalSystem.Domain.Entities.persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Domain.Entities.People
{
    public class Doctor:Person
    {
        [Required]
        [Column("Medical speciality",TypeName = "nvarchar(100)")]
        public required string MedicalSpeciality { get; set; }

        public required string Schedule { get; set; }
        [DataType(DataType.Currency)]
        public required decimal VisitPrice { get; set; }
        [DataType(DataType.Currency)]
        public required decimal FollowUpPrice { get; set; }
        [DataType(DataType.Currency)]

        public required decimal ImpatientVisitPrice { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}

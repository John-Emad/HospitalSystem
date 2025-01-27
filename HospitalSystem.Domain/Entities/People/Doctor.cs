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
        [Key]
        public int Id { get; set; }

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
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
        public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();


    }
}

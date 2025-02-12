using HospitalSystem.Domain.Entities.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Domain.Entities
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int TreatmentId { get; set; }
        [Required]
        public int OperationId { get; set; }
        [Required]
        public  int AdmissionId { get; set; }

        public string? Diagnosis { get; set; }
        public string? Medication { get; set; }
        public string? Notes { get; set; }
        public DateTime Date { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Appointment Appointment { get; set; }

        public virtual Treatment Treatment { get; set; }

        public virtual Operation Operation { get; set; }

        public virtual PatientAdmission PatientAdmission { get; set; }
    }
}

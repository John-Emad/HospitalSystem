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
        public string? Treatment { get; set; }
        public string? Medication { get; set; }
        public string? Notes { get; set; }
        public DateTime Date { get; set; }
    }
}

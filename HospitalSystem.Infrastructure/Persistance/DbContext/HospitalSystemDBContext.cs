using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Entities.People;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Infrastructure.Persistance
{
    public partial class HospitalSystemDBContext : DbContext
    {
        public HospitalSystemDBContext(DbContextOptions<HospitalSystemDBContext> options):base(options)
        {
            
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<PatientAdmission> PatientAdmissions { get; set; }
        public DbSet<MedicalSpeciality> MedicalSpecialities { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PatienBill> PatienBills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasOne(a => a.Hospital)
                .WithMany(d => d.Departments)
                .HasForeignKey(a => a.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Doctor>()
                .HasOne(a => a.MedicalSpeciality)
                .WithMany(d => d.Doctors)
                .HasForeignKey(a => a.MedicalSpecialityId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments) 
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Operation>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.Operations)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Operation>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Operations)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Treatment>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.Treatments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Treatment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Treatments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Treatment>()
                .HasOne(a => a.Appointment)
                .WithOne(d => d.Treatment)
                .HasForeignKey<Treatment>(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .Property(p => p.MedicalRecordNumber)
                .HasMaxLength(50);

            modelBuilder.Entity<PatientAdmission>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.PatientAdmissions)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatientAdmission>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.PatientAdmissions)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Appointment)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Treatment)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.TreatmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Operation)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.OperationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.PatientAdmission)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.AdmissionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Operation)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.OperationId)
                .OnDelete(DeleteBehavior.Cascade);
        }




    }
}

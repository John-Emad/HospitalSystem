using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Entities;
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
        }
    
    }
}

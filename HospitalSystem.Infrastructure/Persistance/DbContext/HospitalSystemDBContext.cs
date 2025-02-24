using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Entities.People;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Infrastructure.Persistance
{
    public partial class HospitalSystemDBContext : DbContext
    {
        #region Constructors
        public HospitalSystemDBContext(DbContextOptions<HospitalSystemDBContext> options):base(options)
        {
            
        }
        #endregion

        #region DataBase Sets (Entities)
        public DbSet<Person> People { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<PatientAdmission> PatientAdmissions { get; set; }
        public DbSet<MedicalSpeciality> MedicalSpecialities { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PatientBill> PatientBills { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Department DataSet (Entitiy) relations
            modelBuilder.Entity<Department>()
                .HasOne(a => a.Hospital)
                .WithMany(d => d.Departments)
                .HasForeignKey(a => a.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Doctor DataSet (Entitiy) relations
            modelBuilder.Entity<Doctor>()
                .HasOne(a => a.MedicalSpeciality)
                .WithMany(d => d.Doctors)
                .HasForeignKey(a => a.MedicalSpecialityId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Appointment DataSet (Entitiy) relations
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
            #endregion

            #region Operation DataSet(Entitiy) relations
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
            #endregion

            #region Treatment DataSet (Entitiy) relations
            modelBuilder.Entity<Treatment>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.Treatments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Treatment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Treatments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Treatment>()
                .HasOne(a => a.Appointment)
                .WithOne(d => d.Treatment)
                .HasForeignKey<Treatment>(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Patient DataSet (Entitiy) relations
            modelBuilder.Entity<Patient>()
                .Property(p => p.MedicalRecordNumber)
                .HasMaxLength(50);
            #endregion

            #region PatientAdmission DataSet (Entitiy) relations
            modelBuilder.Entity<PatientAdmission>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.PatientAdmissions)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PatientAdmission>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.PatientAdmissions)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region PatientBill DataSet (Entitiy) relations
            modelBuilder.Entity<PatientBill>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.PatientBills)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region MedicalRecord DataSet (Entitiy) relations
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Appointment)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Treatment)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.TreatmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Operation)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.OperationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.PatientAdmission)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.AdmissionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(a => a.Operation)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.OperationId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

        }
    }
}

using MedCare_Hospital.DataStructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyHospital_MVC.Models;

namespace MedCare_Hospital.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<HealthcareProvider> HealthcareProviders { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<PatientHealthcareProvider> PatientHealthcareProviders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Many to Many
            modelBuilder.Entity<PatientHealthcareProvider>()
                .HasKey(ph => new { ph.PatientId, ph.HealthcareProviderId });

            modelBuilder.Entity<PatientHealthcareProvider>()
                .HasOne(p => p.Patient)
                .WithMany(t => t.PatientHealthcareProvider)
                .HasForeignKey(pt => pt.PatientId);

            modelBuilder.Entity<PatientHealthcareProvider>()
           .HasOne(hp => hp.HealthcareProvider)
           .WithMany(p => p.PatientHealthcareProvider)
           .HasForeignKey(pt => pt.HealthcareProviderId);


            modelBuilder.Entity<Patient>()
                .HasOne(p => p.MedicalRecord)
                .WithOne(m => m.Patient)
                .HasForeignKey<MedicalRecord>(m => m.PatientId);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbContext()
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(p =>
                    p.HasData(
                        new Patient { IdPatient = 1, FirstName = "Jan", LastName = "Kowalski", BirthDate = DateTime.Parse("2000-01-01") },
                        new Patient { IdPatient = 2, FirstName = "Michał", LastName = "Kamień", BirthDate = DateTime.Parse("2010-02-11") }
                        )
                );

            modelBuilder.Entity<Doctor>(p =>
                p.HasData(
                        new Doctor { IdDoctor = 1, FirstName = "Kamil", LastName = "Będzin", Email = "kabe@gmail.com" },
                        new Doctor { IdDoctor = 2, FirstName = "Karol", LastName = "Troll", Email = "karol.troll@gmail.com" }
                ));

            modelBuilder.Entity<Prescription>(p =>
                p.HasData(
                        new Prescription { IdPrescription = 1, IdDoctor = 1, IdPatient = 2, Date = DateTime.Parse("2012-09-12"), DueDate = DateTime.Parse("2013-09-12") },
                        new Prescription { IdPrescription = 2, IdDoctor = 2, IdPatient = 1, Date = DateTime.Parse("2010-09-12"), DueDate = DateTime.Parse("2011-09-12") }
                ));

            modelBuilder.Entity<Medicament>(p =>
                p.HasData(
                        new Medicament { IdMedicament = 1, Name = "Lek 1", Description = "Leczy anginę", Type = "W płnie" },
                        new Medicament { IdMedicament = 2, Name = "Lek 2", Description = "Leczy zapalenie płuc", Type = "Tabletki" }
                ));

            modelBuilder.Entity<PrescriptionMedicament>(p =>
            {
                p.HasKey(u => new
                {
                    u.IdMedicament,
                    u.IdPrescription
                });

                p.HasData(
                        new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 2, Dose = 3, Details = "Detail 1" },
                        new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 1, Dose = 2, Details = "Detail 2" },
                        new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "Detail 3" }
                        );
            });
        }
    }
}

using System;
using EmployeeSignInSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeSignInSystem.DataDB
{
    public partial class EmployeeSigningSystemContext : DbContext
    {
        public EmployeeSigningSystemContext()
        {
        }

        public EmployeeSigningSystemContext(DbContextOptions<EmployeeSigningSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeTempBadge> EmployeeTempBadge { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HSHLT-1694\\SQLEXPRESS01;Database=EmployeeSigningSystem;Trusted_Connection=True; trustservercertificate = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).IsRequired();
            });

            modelBuilder.Entity<EmployeeTempBadge>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.AssignT).HasColumnType("datetime");

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SignInT).HasColumnType("datetime");

                entity.Property(e => e.SignOutT).HasColumnType("datetime");

                entity.Property(e => e.TempBadge)
                    
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<EmployeeSignInSystem.Models.EmpQueueDetails> EmpQueueDetails { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BloodServer.DTO.Models
{
    public partial class BloodManagementContext : DbContext
    {
        public BloodManagementContext()
        {
        }

        public BloodManagementContext(DbContextOptions<BloodManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<BloodTest> BloodTests { get; set; }
        public virtual DbSet<BloodType> BloodTypes { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ASUS-LAURA;Database=BloodManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDe).HasColumnType("datetime");

                entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");

                entity.Property(e => e.RequestId).HasColumnName("Request_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_Appointments_Hospitals");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Appointments_Users");
            });

            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<BloodTest>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aids).HasColumnName("AIDS");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");

                entity.Property(e => e.HepatitisB).HasColumnName("Hepatitis_B");

                entity.Property(e => e.HepatitisC).HasColumnName("Hepatitis_C");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.BloodTests)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_BloodTests_Appointments");
            });

            modelBuilder.Entity<BloodType>(entity =>
            {
                entity.ToTable("BloodType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Blood).HasMaxLength(50);

                entity.Property(e => e.Rh).HasColumnName("RH");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(11);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BloodId).HasColumnName("Blood_ID");

                entity.Property(e => e.Cnp)
                    .HasMaxLength(50)
                    .HasColumnName("CNP");

                entity.Property(e => e.Illness).HasMaxLength(50);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.StaffId).HasColumnName("Staff_ID");

                entity.Property(e => e.TargetFirstName).HasMaxLength(50);

                entity.Property(e => e.TargetLastName).HasMaxLength(50);

                entity.HasOne(d => d.Blood)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.BloodId)
                    .HasConstraintName("FK_Requests_BloodType");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Requests_Staff");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BloodId).HasColumnName("Blood_ID");

                entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");

                entity.HasOne(d => d.Blood)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.BloodId)
                    .HasConstraintName("FK_Stocks_BloodType");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_Stocks_Hospitals");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BloodId).HasColumnName("BloodID");

                entity.Property(e => e.Cnp)
                    .HasMaxLength(50)
                    .HasColumnName("CNP");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Blood)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BloodId)
                    .HasConstraintName("FK_Users_BloodType");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorizationId).HasColumnName("Authorization_ID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Authorization)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.AuthorizationId)
                    .HasConstraintName("FK_Staff_Authorizations");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_Staff_Hospitals");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

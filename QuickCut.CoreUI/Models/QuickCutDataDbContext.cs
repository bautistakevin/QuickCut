using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuickCut.CoreUI.Models
{
    public partial class QuickCutDataDbContext : DbContext
    {
        public QuickCutDataDbContext()
        {
        }

        public QuickCutDataDbContext(DbContextOptions<QuickCutDataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Barber> Barber { get; set; }
        public virtual DbSet<BarberDetails> BarberDetails { get; set; }
        public virtual DbSet<Consumer> Consumer { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Zip> Zip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Initial Catalog=QuickCut.Data;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__Appointm__8ECDFCA297A02237");

                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");

                entity.Property(e => e.BarberId).HasColumnName("BarberID");

                entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Barber)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.BarberId)
                    .HasConstraintName("FK_dbo.Appointments_dbo.Barber_BarberID");

                entity.HasOne(d => d.Consumer)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ConsumerId)
                    .HasConstraintName("FK_dbo.Appointments_dbo.Consumer_ConsumerID");
            });

            modelBuilder.Entity<Barber>(entity =>
            {
                entity.Property(e => e.BarberId).HasColumnName("BarberID");

                entity.Property(e => e.BarberAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BarberDetails>(entity =>
            {
                entity.HasKey(e => e.BarberId)
                    .HasName("PK__BarberDe__BE22A88EC12CCD32");

                entity.Property(e => e.BarberId)
                    .HasColumnName("BarberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DaysOfWeek)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OperationHours)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyInfo)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Barber)
                    .WithOne(p => p.BarberDetails)
                    .HasForeignKey<BarberDetails>(d => d.BarberId)
                    .HasConstraintName("FK_dbo.BarberDetails_dbo.Barber_BarberID");
            });

            modelBuilder.Entity<Consumer>(entity =>
            {
                entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__Ratings__FCCDF85C31E16911");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.BarberId).HasColumnName("BarberID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");

                entity.HasOne(d => d.Barber)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.BarberId)
                    .HasConstraintName("FK_dbo.Ratings_dbo.Barber_BarberID");

                entity.HasOne(d => d.Consumer)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ConsumerId)
                    .HasConstraintName("FK_dbo.Ratings_dbo.Consumer_ConsumerID");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.BarberId)
                    .HasName("PK__Services__BE22A88E65064A7C");

                entity.Property(e => e.BarberId)
                    .HasColumnName("BarberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ServiceDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Barber)
                    .WithOne(p => p.Services)
                    .HasForeignKey<Services>(d => d.BarberId)
                    .HasConstraintName("FK_dbo.Services_dbo.Barber_BarberID");
            });

            modelBuilder.Entity<Zip>(entity =>
            {
                entity.HasKey(e => e.Zip1)
                    .HasName("PK__ZIP__D8F67F7EA0182C54");

                entity.ToTable("ZIP");

                entity.Property(e => e.Zip1)
                    .HasColumnName("Zip")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}

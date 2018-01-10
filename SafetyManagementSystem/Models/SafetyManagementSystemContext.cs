using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SafetyManagementSystem.Models
{
    public partial class SafetyManagementSystemContext : DbContext
    {
        public virtual DbSet<HazardCategories> HazardCategories { get; set; }
        public virtual DbSet<HazardReports> HazardReports { get; set; }
        public virtual DbSet<Incidents> Incidents { get; set; }
        public virtual DbSet<Sites> Sites { get; set; }

        public SafetyManagementSystemContext(DbContextOptions<SafetyManagementSystemContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.QueryClientEvaluationWarning));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HazardCategories>(entity =>
            {
                entity.HasKey(e => e.HazardCategoryId);

                entity.Property(e => e.HazardCategory)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HazardReports>(entity =>
            {
                entity.HasKey(e => e.HazardReportId);

                entity.Property(e => e.AdminDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AdminEmployee)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AffectedPersonnel)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CorrectiveAction)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CostOfPurchases).HasColumnType("money");

                entity.Property(e => e.DateImplemented).HasColumnType("smalldatetime");

                entity.Property(e => e.HazardLocation)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HazardPotential)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.HazardReportDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvolvedMaterial)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Issue)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Manager)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RegulatoryViolation)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReportedByEmpDept)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReportedByEmployee)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SuggestedCorrections)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Supervisor)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Witnesses)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.HazardCategory)
                    .WithMany(p => p.HazardReports)
                    .HasForeignKey(d => d.HazardCategoryId)
                    .HasConstraintName("FK_HazardReports_HazardCategories");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.HazardReports)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HazardReports_Sites");
            });

            modelBuilder.Entity<Incidents>(entity =>
            {
                entity.HasKey(e => e.IncidentId);

                entity.Property(e => e.DateEntered)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeFname)
                    .HasColumnName("EmployeeFName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeLname)
                    .HasColumnName("EmployeeLName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EventLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InjuryDescription)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.PreventativeActions)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidents_Sites");
            });

            modelBuilder.Entity<Sites>(entity =>
            {
                entity.HasKey(e => e.SiteId);

                entity.Property(e => e.SafetyRepEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SafetyRepName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}

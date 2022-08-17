using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFDBFirst.Data.Models
{
    public partial class DBFirstContext : DbContext
    {
        public DBFirstContext()
        {
        }

        public DBFirstContext(DbContextOptions<DBFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeEducation> EmployeeEducations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0P56O06;Database=DBFirst;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB9921E65EA4");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId).ValueGeneratedNever();

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeEducation>(entity =>
            {
                entity.HasKey(e => e.EduId)
                    .HasName("PK__Employee__1FD9490EC307B73D");

                entity.ToTable("EmployeeEducation");

                entity.Property(e => e.EduId).ValueGeneratedNever();

                entity.Property(e => e.EducationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeEducations)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__EmployeeE__EmpID__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

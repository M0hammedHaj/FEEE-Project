using System;
using System.Collections.Generic;
using FEEE.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace FEEE.Infrastructure.Persistence;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<OperationType> OperationTypes { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentArchive> StudentArchives { get; set; }

    public virtual DbSet<StudentPromotion> StudentPromotions { get; set; }

    public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Year> Years { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=FEEEDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21A967D838E2A");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<OperationType>(entity =>
        {
            entity.HasKey(e => e.OperationTypeId).HasName("PK__Operatio__FF7FE533B7801D67");

            entity.Property(e => e.OperationTypeId).HasColumnName("OperationTypeID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF089226AFA231");

            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasMany(d => d.Subjects).WithMany(p => p.Sections)
                .UsingEntity<Dictionary<string, object>>(
                    "SectionSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SectionSubjects_Subjects"),
                    l => l.HasOne<Section>().WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SectionSubjects_Sections"),
                    j =>
                    {
                        j.HasKey("SectionId", "SubjectId");
                        j.ToTable("SectionSubjects");
                        j.IndexerProperty<int>("SectionId").HasColumnName("SectionID");
                        j.IndexerProperty<int>("SubjectId").HasColumnName("SubjectID");
                    });
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A790CFDD26F");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.FatherName).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.MotherName).HasMaxLength(20);
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.UniversityNumber).HasMaxLength(20);
            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.City).WithMany(p => p.Students)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Students_Cities");

            entity.HasOne(d => d.Section).WithMany(p => p.Students)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_Students_Sections");

            entity.HasOne(d => d.Year).WithMany(p => p.Students)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("FK_Students_Years");
        });

        modelBuilder.Entity<StudentArchive>(entity =>
        {
            entity.HasKey(e => e.StudentArchiveId).HasName("PK__StudentA__BE0F4C296DF0556B");

            entity.ToTable("StudentArchive");

            entity.Property(e => e.StudentArchiveId).HasColumnName("StudentArchiveID");
            entity.Property(e => e.ArchiveDate).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(50);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.OperationTypeNavigation).WithMany(p => p.StudentArchives)
                .HasForeignKey(d => d.OperationType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentArchive_OperationTypes");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentArchives)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentArchive_Students");

            entity.HasOne(d => d.User).WithMany(p => p.StudentArchives)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentArchive_Users");
        });

        modelBuilder.Entity<StudentPromotion>(entity =>
        {
            entity.HasKey(e => e.StudentPromotionId).HasName("PK__StudentP__A1CA55D8E2A43EDC");

            entity.ToTable("StudentPromotion");

            entity.Property(e => e.StudentPromotionId).HasColumnName("StudentPromotionID");
            entity.Property(e => e.FromYearId).HasColumnName("FromYearID");
            entity.Property(e => e.PromotionDate).HasColumnType("datetime");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ToYearId).HasColumnName("ToYearID");

            entity.HasOne(d => d.FromYear).WithMany(p => p.StudentPromotionFromYears)
                .HasForeignKey(d => d.FromYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentPromotion_FromYear");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentPromotions)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentPromotion_Students");

            entity.HasOne(d => d.ToYear).WithMany(p => p.StudentPromotionToYears)
                .HasForeignKey(d => d.ToYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentPromotion_ToYear");
        });

        modelBuilder.Entity<StudentSubject>(entity =>
        {
            entity.HasKey(e => e.StudentSubjectId).HasName("PK__StudentS__54F6B8C1332DC99B");

            entity.Property(e => e.StudentSubjectId).HasColumnName("StudentSubjectID");
            entity.Property(e => e.AcademicYear).HasMaxLength(20);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentSubjects)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjects_Students");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudentSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjects_Subjects");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA38869824235");

            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.Year).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("FK_Subjects_Years");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACF5B11963");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(30);
            entity.Property(e => e.Username).HasMaxLength(30);
        });

        modelBuilder.Entity<Year>(entity =>
        {
            entity.HasKey(e => e.YearId).HasName("PK__Years__C33A18ADD0DBE850");

            entity.Property(e => e.YearId).HasColumnName("YearID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEEE.Infrastructure.Persistence.Data.Configuration
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {

        public void Configure(EntityTypeBuilder<StudentSubject> entity)
        {
            entity.HasKey(e => e.StudentSubjectId)
                           .HasName("PK__StudentS__54F6B8C1332DC99B");

            entity.Property(e => e.StudentSubjectId)
                .HasColumnName("StudentSubjectID");

            entity.Property(e => e.StudentId)
                .HasColumnName("StudentID");

            entity.Property(e => e.SubjectId)
                .HasColumnName("SubjectID");

            entity.Property(e => e.YearId)
                .HasColumnName("YearID");

            entity.Property(e => e.Semester);

            entity.Property(e => e.Status);

            entity.HasOne(d => d.Student)
                .WithMany(p => p.StudentSubjects)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjects_Students");

            entity.HasOne(d => d.Subject)
                .WithMany(p => p.StudentSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjects_Subjects");

            // ✅ العلاقة الجديدة
            entity.HasOne(d => d.Year)
                .WithMany(p => p.StudentSubjects)
                .HasForeignKey(d => d.YearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjects_Years");


        }



    }







}

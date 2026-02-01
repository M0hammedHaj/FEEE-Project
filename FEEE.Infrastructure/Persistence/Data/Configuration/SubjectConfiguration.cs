using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEEE.Infrastructure.Persistence.Data.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> entity)
        {
            entity.HasKey(e => e.SubjectId)
                  .HasName("PK__Subjects__AC1BA38869824235");

            entity.Property(e => e.SubjectId)
                  .HasColumnName("SubjectID");

            entity.Property(e => e.Code)
                  .HasMaxLength(20);

            entity.Property(e => e.Name)
                  .HasMaxLength(50);

            entity.Property(e => e.YearId)
                  .HasColumnName("YearID");

            entity.Property(e => e.SectionId)
                  .HasColumnName("SectionID");

            // Subject -> Year (optional)
            entity.HasOne(d => d.Year)
                  .WithMany(p => p.Subjects)
                  .HasForeignKey(d => d.YearId)
                  .HasConstraintName("FK_Subjects_Years");

            // Subject -> Semester (required)
            entity.HasOne(x => x.Semester)
                  .WithMany(s => s.Subjects)
                  .HasForeignKey(x => x.SemesterId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_Subjects_Semesters");

            // ⭐ Subject -> Section (المطلوب)
            entity.HasOne(s => s.Section)
                  .WithMany(sec => sec.Subjects)
                  .HasForeignKey(s => s.SectionId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_Subjects_Sections");
        }
    }
}

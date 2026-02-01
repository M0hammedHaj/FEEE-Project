using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEEE.Infrastructure.Persistence.Data.Configuration
{
    public class StudentPromotionConfiguration : IEntityTypeConfiguration<StudentPromotion>
    {

        public void Configure(EntityTypeBuilder<StudentPromotion> entity)
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


        }



    }


    



}

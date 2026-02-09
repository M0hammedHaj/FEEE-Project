using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEEE.Infrastructure.Persistence.Data.Configuration
{
    public class StudentArchiveConfiguration : IEntityTypeConfiguration<StudentArchive>
    {

        public void Configure(EntityTypeBuilder<StudentArchive> entity)
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


        }



    }






}

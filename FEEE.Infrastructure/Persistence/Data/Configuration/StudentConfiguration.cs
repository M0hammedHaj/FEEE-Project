using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEEE.Infrastructure.Persistence.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {

        public void Configure(EntityTypeBuilder<Student> entity)
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



            entity.Property(e => e.SectionId)
      .HasColumnName("SectionID");

            entity.HasOne(e => e.Section)
                  .WithMany(s => s.Students)
                  .HasForeignKey(e => e.SectionId)
                  .HasConstraintName("FK_Students_Sections");




        }



    }






}

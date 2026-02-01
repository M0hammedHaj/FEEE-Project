using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Infrastructure.Persistence.Data.Configuration
{
    internal class SemesterConfiguration
         : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            // Table name
            builder.ToTable("Semesters");

            // Primary Key
            builder.HasKey(x => x.SemesterId);

            // Properties
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Order)
                   .IsRequired();

            builder.Property(x => x.IsActive)
                   .IsRequired();

            // Relationship: Semester -> Year
            builder.HasOne(x => x.Year)
                   .WithMany(y => y.Semesters)
                   .HasForeignKey(x => x.YearId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relationship: Semester -> Subjects
            builder.HasMany(x => x.Subjects)
                   .WithOne(s => s.Semester)
                   .HasForeignKey(s => s.SemesterId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

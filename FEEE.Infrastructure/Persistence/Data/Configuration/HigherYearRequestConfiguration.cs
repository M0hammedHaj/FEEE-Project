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
    internal class HigherYearRequestConfiguration : IEntityTypeConfiguration<HigherYearRequest>
    {
        public void Configure(EntityTypeBuilder<HigherYearRequest> builder)
        {
            builder.ToTable("HigherYearRequests");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                   .IsRequired();

            builder.Property(x => x.Status)
                   .HasConversion<byte>()
                   .IsRequired();

            builder.HasOne(x => x.Student)
                   .WithMany()
                   .HasForeignKey(x => x.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Year)
                   .WithMany()
                   .HasForeignKey(x => x.YearId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Section)
                   .WithMany()
                   .HasForeignKey(x => x.SectionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Semester)
                   .WithMany()
                   .HasForeignKey(x => x.SemesterId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

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
    internal class HigherYearRequestSubjectConfiguration : IEntityTypeConfiguration<HigherYearRequestSubject>
    {
        public void Configure(EntityTypeBuilder<HigherYearRequestSubject> builder)
        {
            builder.ToTable("HigherYearRequestSubjects");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.RequestId, x.SubjectId })
                   .IsUnique();

            builder.HasOne(x => x.Request)
                   .WithMany(r => r.HigherYearRequestSubjects)
                   .HasForeignKey(x => x.RequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Subject)
                   .WithMany()
                   .HasForeignKey(x => x.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

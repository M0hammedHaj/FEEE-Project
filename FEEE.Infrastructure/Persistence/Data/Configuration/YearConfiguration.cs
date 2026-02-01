using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEEE.Infrastructure.Persistence.Data.Configuration
{
    public class YearConfiguration : IEntityTypeConfiguration<Year>
    { 

        public void Configure(EntityTypeBuilder<Year> entity)
        {

            entity.HasKey(e => e.YearId).HasName("PK__Years__C33A18ADD0DBE850");

            entity.Property(e => e.YearId).HasColumnName("YearID");
            entity.Property(e => e.Name).HasMaxLength(50);


        }



    }





}

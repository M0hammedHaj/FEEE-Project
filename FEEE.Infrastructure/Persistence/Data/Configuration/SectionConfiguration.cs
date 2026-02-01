using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEEE.Infrastructure.Persistence.Data.Configuration
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> entity)
        {
            entity.HasKey(e => e.SectionId)
                  .HasName("PK__Sections__80EF089226AFA231");

            entity.Property(e => e.SectionId)
                  .HasColumnName("SectionID");

            entity.Property(e => e.Name)
                  .HasMaxLength(50);

          
        }
    }
}

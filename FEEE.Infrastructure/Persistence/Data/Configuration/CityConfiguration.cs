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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {

        public void Configure(EntityTypeBuilder<City> entity)
        {

            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21A967D838E2A");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Name).HasMaxLength(50);


        }



    }





}

using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEEE.Infrastructure.Persistence.Data.Configuration
{
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {

        public void Configure(EntityTypeBuilder<OperationType> entity)
        {

            entity.HasKey(e => e.OperationTypeId).HasName("PK__Operatio__FF7FE533B7801D67");

            entity.Property(e => e.OperationTypeId).HasColumnName("OperationTypeID");
            entity.Property(e => e.Name).HasMaxLength(50);


        }





    }




}

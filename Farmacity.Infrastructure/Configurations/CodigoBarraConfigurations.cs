using Farmacity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farmacity.Infrastructure.Configurations;

public class CodigoBarraConfigurations : EntityTypeBaseConfiguration<CodigoBarra>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<CodigoBarra> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Producto).WithMany(x => x.CodigosBarras).HasForeignKey(x => x.ProductoId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<CodigoBarra> builder)
    {
        builder.Property(x => x.Codigo)
            .IsRequired()
            .HasMaxLength(250);
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<CodigoBarra> builder)
    {
        builder.ToTable("CodigosBarras");
    }
}

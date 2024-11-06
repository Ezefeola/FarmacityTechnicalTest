using Farmacity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farmacity.Infrastructure.Configurations;

public class ProductoConfigurations : EntityTypeBaseConfiguration<Producto>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Producto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.CodigosBarras).WithOne(x => x.Producto).HasForeignKey(x => x.ProductoId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Producto> builder)
    {
        builder.Property(x => x.Nombre)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(x => x.Activo)
            .IsRequired();

        builder.Property(x => x.Precio)
            .HasPrecision(18, 2);
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Productos");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class FacturaDetalleConfig : IEntityTypeConfiguration<FacturaDetalle>
    {
        public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
        {
            //Se guarda el valor calculado en BDD:
            builder.Property(f => f.Total)
                    .HasComputedColumnSql("Precio * Cantidad", stored: true);
            //No se guarda el valor calculado, sino que se calcula en el momento:
            builder.Property(f => f.Total)
                    .HasComputedColumnSql("Precio * Cantidad");
        }
    }
}

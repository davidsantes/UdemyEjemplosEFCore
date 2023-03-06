using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class FacturaConfig : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable(name: "Facturas", opciones =>
            {
                opciones.IsTemporal(t =>
                {
                    t.HasPeriodStart("Desde");
                    t.HasPeriodEnd("Hasta");
                    t.UseHistoryTable(name: "FacturasHistorico");
                });
            });

            builder.Property("Desde").HasColumnType("datetime2");
            builder.Property("Hasta").HasColumnType("datetime2");

            builder.HasMany(typeof(FacturaDetalle)).WithOne();

            //El esquema "factura" se configura en el modelbuilder de. DbContext: modelBuilder.HasSequence<int>("NumeroFactura", "factura");
            builder.Property(f => f.NumeroFactura)
                .HasDefaultValueSql("NEXT VALUE FOR factura.NumeroFactura");

            //Conflictos de concurrencia por fila, la alternativa es en la clase poner [Timestamp]:
            //builder.Property(f => f.Version).IsRowVersion();
        }
    }
}

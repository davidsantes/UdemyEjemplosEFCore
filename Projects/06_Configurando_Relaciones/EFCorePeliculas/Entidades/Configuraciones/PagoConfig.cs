using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PagoConfig : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            //Herencia de clases - tabla por jerarquía
            //Permite a EF indicar en la relación entre una clase derivada utilizada, y el enum correspondiente un registro:
            builder.HasDiscriminator(p => p.TipoPago)
                .HasValue<PagoPaypal>(TipoPago.Paypal)
                .HasValue<PagoTarjeta>(TipoPago.Tarjeta);

            builder.Property(p => p.Monto).HasPrecision(18, 2);
        }
    }
}

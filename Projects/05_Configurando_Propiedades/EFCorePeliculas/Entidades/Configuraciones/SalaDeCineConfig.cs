using EFCorePeliculas.Entidades.Conversiones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            builder.Property(prop => prop.Precio)
                .HasPrecision(precision: 9, scale: 2);

            //Para realizar conversión de un enum a un string, y que guarde en BDD un string:
            builder.Property(prop => prop.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones)
                .HasConversion<string>();

            //Para realizar conversión de un enum a un string de moneda:
            builder.Property(prop => prop.Moneda)
                .HasConversion<MonedaASimboloConverter>();
        }
    }
}

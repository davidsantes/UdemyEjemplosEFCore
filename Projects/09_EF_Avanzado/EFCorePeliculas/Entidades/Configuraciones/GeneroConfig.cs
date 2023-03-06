using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            //Tabla temporal: para configurar la tabla como temporal, para poder almacenar históricos:
            builder.ToTable(name: "Generos", opciones =>
            {
                opciones.IsTemporal();
            });

            //Tabla temporal: necesita que elas propiedades puedan almacenar horas, minutos, etcétera
            builder.Property("PeriodStart").HasColumnType("datetime2");
            builder.Property("PeriodEnd").HasColumnType("datetime2");

            builder.HasKey(prop => prop.Identificador);
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
                //.IsConcurrencyToken(); Para evitar concurrencias en un campo.

            builder.HasQueryFilter(g => !g.EstaBorrado);

            builder.HasIndex(g => g.Nombre).IsUnique().HasFilter("EstaBorrado = 'false'");

            builder.Property<DateTime>("FechaCreacion").HasDefaultValueSql("GetDate()").HasColumnType("datetime2");
        }
    }
}

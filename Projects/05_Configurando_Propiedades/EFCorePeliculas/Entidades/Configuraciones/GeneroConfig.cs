using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(prop => prop.Identificador);
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            //Filtros al nivel del modelo:
            builder.HasQueryFilter(g => !g.EstaBorrado);

            //Índice parcial:
            builder.HasIndex(g => g.Nombre)
                .IsUnique()
                .HasFilter("EstaBorrado = 'false'");

            //Propiedades sombra:
            builder.Property<DateTime>("FechaCreacion")
                .HasDefaultValueSql("GetDate()")
                .HasColumnType("datetime2");
        }
    }
}

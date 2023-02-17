using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModeladoBdd.Entidades;

namespace ModeladoBdd.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(prop => prop.Identificador);
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
            
            //Para hacer el cambio de nombre a una columna que no sigue la convención de nombres:
            //builder.Property(prop => prop.Nombre).HasColumnName("NombreGenero");
            //Para hacer el cambio de nombre a una tabla que no sigue la convención de nombres:
            //builder.ToTable(name: "TablaGeneros", schema: "Peliculas");
        }
    }
}

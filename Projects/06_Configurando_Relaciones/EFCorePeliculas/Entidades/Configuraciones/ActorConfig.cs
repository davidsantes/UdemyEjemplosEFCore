using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Nombre)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.Nombre).HasField("_nombre");

            //División de una tabla (Table Splitting) mediante entidades de propiedad (reutilización de entidades secundarias Owned)
            //Para renombrar las columnas con un nombre concreto:
            builder.OwnsOne(a => a.DireccionHogar, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("Calle");
                dir.Property(d => d.Provincia).HasColumnName("Provincia");
                dir.Property(d => d.Pais).HasColumnName("Pais");
            });
        }
    }
}

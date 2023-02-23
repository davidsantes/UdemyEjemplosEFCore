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

            //Para ignorar una propiedad:
            //builder.Ignore(a => a.Edad);
            //Para ignorar una propiedad que es una clase:
            //builder.Ignore(a => a.Direccion);
        }
    }
}

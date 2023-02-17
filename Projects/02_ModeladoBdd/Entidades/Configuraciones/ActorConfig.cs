using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModeladoBdd.Entidades;

namespace ModeladoBdd.Entidades.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Nombre)
               .HasMaxLength(150)
               .IsRequired();
            //Para hacer el cambio de tipo, y que no sea datetime, sino solo date:
            //builder.Property(prop => prop.FechaNacimiento).HasColumnType("date");
        }
    }
}

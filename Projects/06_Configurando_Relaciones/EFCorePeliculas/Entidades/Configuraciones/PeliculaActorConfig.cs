using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            //Configuración de llave primaria compuesta
            builder.HasKey(prop =>
             new { prop.PeliculaId, prop.ActorId });


            //Relación N a N mediante fluent API
            builder.HasOne(pa => pa.Actor)
                    .WithMany(a => a.PeliculasActores)
                    .HasForeignKey(pa => pa.ActorId);

            //Relación N a N mediante fluent API
            builder.HasOne(pa => pa.Pelicula)
                    .WithMany(p => p.PeliculasActores)
                    .HasForeignKey(pa => pa.PeliculaId);

            builder.Property(prop => prop.Personaje)
                .HasMaxLength(150);
        }
    }
}

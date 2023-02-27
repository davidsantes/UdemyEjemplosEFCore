using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(prop => prop.Titulo)
             .HasMaxLength(250)
             .IsRequired();

            builder.Property(prop => prop.PosterURL)
                .HasMaxLength(500)
                .IsUnicode(false);

            //Relación N a N con Fluent API sin clase intermedia(skip navigation):
            //builder.HasMany(p => p.Generos)
            //    .WithMany(g => g.Peliculas)
            //    .UsingEntity(j => 
            //        j.ToTable("GenerosPeliculas")
            //        .HasData(new { PeliculasId = 1, GenerosIdentificador = 7 })
            //        );
        }
    }
}

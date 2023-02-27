using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.Property(prop => prop.Nombre)
              .HasMaxLength(150)
              .IsRequired();

            //Relación 1 a 1 mediante fluent API
            //HasOne: 1 Cine tiene 1 CineOferta
            //WithOne: 1 CineOferta tiene 1 Cine
            builder.HasOne(c => c.CineOferta)
                .WithOne()
                .HasForeignKey<CineOferta>(co => co.CineId);

            //Relación 1 a N mediante fluent API
            //HasMany: 1 Cine tiene N SalaDeCine
            //WithOne: 1 SalaDeCine tiene 1 Cine
            //OnDelete: DeleteBehavior.Restrict: para un borrado estricto, primero habrá que eliminar la entidades hijas
            builder.HasMany(c => c.SalasDeCine)
                .WithOne(s => s.Cine)
                .HasForeignKey(s => s.ElCine)
                .OnDelete(DeleteBehavior.Restrict);

            //División de una tabla (Table Splitting) en más de una entidad (datos principales y secundarios)
            //La llave foránea será su propio Id, que es compartido con el padre:
            builder.HasOne(c => c.CineDetalle).WithOne(cd => cd.Cine)
                .HasForeignKey<CineDetalle>(cd => cd.Id);

            //División de una tabla (Table Splitting) mediante entidades de propiedad (reutilización de entidades secundarias Owned)
            //Para renombrar las columnas con un nombre concreto:
            builder.OwnsOne(c => c.Direccion, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("Calle");
                dir.Property(d => d.Provincia).HasColumnName("Provincia");
                dir.Property(d => d.Pais).HasColumnName("Pais");
            });
        }
    }
}

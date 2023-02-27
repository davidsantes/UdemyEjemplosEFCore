using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class CineDetalleConfig : IEntityTypeConfiguration<CineDetalle>
    {
        public void Configure(EntityTypeBuilder<CineDetalle> builder)
        {
            //División de una tabla (Table Splitting) en más de una entidad (datos principales y secundarios)
            //Que mapee con la tabla [Cines]:
            builder.ToTable("Cines");
        }
    }
}

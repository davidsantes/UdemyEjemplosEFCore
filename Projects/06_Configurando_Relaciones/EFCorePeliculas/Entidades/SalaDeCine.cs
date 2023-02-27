using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    public class SalaDeCine
    {
        public int Id { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        public decimal Precio { get; set; }
        public int ElCine { get; set; }
        //Relaciones con anotaciones de datos: el atributo [ForeignKey] para llaves foráneas:
        [ForeignKey(nameof(ElCine))]
        public Cine Cine { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
        public Moneda Moneda { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeladoBdd.Entidades
{
    //[Table("TablaGeneros", Schema = "peliculas")]
    public class Genero
    {
        //[Key]
        public int Identificador { get; set; }
        //StringLength y MaxLength son dos opciones para realizar la misma configuración
        //[StringLength(150)] o [MaxLength(150)]
        //
        //[Column("NombreGenero")]
        //[Required]
        public string Nombre { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}

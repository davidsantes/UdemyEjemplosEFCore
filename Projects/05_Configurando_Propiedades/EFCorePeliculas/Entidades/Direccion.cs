using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    //Para ignorar en cualquier ámbito esta clase:
    [NotMapped]
    public class Direccion
    {
        public string Calle { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    public class Log
    {
        //Para evitar que genere un valor en la propiedad de manera automática, aunque no es recomendable
        //y es mejor dejarlo a EF:
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Mensaje { get; set; }
    }
}

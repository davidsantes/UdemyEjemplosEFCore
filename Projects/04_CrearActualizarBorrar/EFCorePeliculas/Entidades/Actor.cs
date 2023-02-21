using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    public class Actor
    {
        public int Id { get; set; }
        private string _nombre;
        //La primera letra de cada palabra (nombre, ape1), estarán siempre en mayúscula.
        public string Nombre {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = string.Join(' ',
                        value.Split(' ')
                        .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }        
        }
        public string Biografia { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime? FechaNacimiento { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}

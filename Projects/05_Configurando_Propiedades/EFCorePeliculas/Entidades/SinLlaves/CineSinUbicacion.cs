using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades.SinLlaves
{
    /// <summary>
    /// Esta clase corresponde a una sentencia SQL personalizada
    /// </summary>
    //[Keyless]
    public class CineSinUbicacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}

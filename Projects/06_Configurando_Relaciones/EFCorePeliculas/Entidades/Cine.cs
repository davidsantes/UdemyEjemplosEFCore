using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
        //División de una tabla (Table Splitting) en más de una entidad (datos principales y secundarios):
        public CineDetalle CineDetalle { get; set; }
        //División de una tabla(Table Splitting) mediante entidades de propiedad(reutilización de entidades secundarias):
        public Direccion Direccion { get; set; }
    }
}

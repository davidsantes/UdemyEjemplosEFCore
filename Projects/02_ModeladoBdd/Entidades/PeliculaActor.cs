namespace ModeladoBdd.Entidades
{
    public class PeliculaActor
    {
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
        public string Personaje { get; set; }
        /// <summary>
        /// Orden en el que se mostrarán los actores dentro de una película.
        /// </summary>
        public int Orden { get; set; }
        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
    }
}

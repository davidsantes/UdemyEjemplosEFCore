namespace EFCorePeliculas.Servicios
{
    public class ServicioSingletonFallo
    {
        private readonly ApplicationDbContext context;

        public ServicioSingletonFallo(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
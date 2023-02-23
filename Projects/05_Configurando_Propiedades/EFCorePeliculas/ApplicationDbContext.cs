using EFCorePeliculas.Entidades;
using EFCorePeliculas.Entidades.Configuraciones;
using EFCorePeliculas.Entidades.Seeding;
using EFCorePeliculas.Entidades.SinLlaves;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCorePeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingModuloConsulta.Seed(modelBuilder);

            //Para evitar que genere un valor en la propiedad de manera automática, aunque no es recomendable
            //y es mejor dejarlo a EF:
            //modelBuilder.Entity<Log>().Property(l => l.Id).ValueGeneratedNever();

            //Para ignorar en cualquier ámbito esta clase:
            //modelBuilder.Ignore<Direccion>();

            //Keyless (entidades sin Llave), ejecución de sentencias SQL:
            //ToView(null) se utiliza para que no se agregue una tabla en la BDD con un esquema de CineSinUbicacion:
            modelBuilder.Entity<CineSinUbicacion>()
                .HasNoKey()
                .ToSqlQuery("Select Id, Nombre FROM Cines").ToView(null);

            //Keyless (entidades sin Llave), ejecución de sentencias SQL:
            modelBuilder.Entity<PeliculaConConteos>()
                .HasNoKey()
                .ToView("PeliculasConConteos");

            //Configuración masiva de propiedades mediante automaticación de Fluent API
            //Iteración de todas las entidades para configurar cualquier string que contenga "URL"
            //Se considerará en BDD no unicode y tendrá un tamaño máximo de 500 caracteres:
            foreach (var tipoEntidad in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var propiedad in tipoEntidad.GetProperties())
                {
                    if (propiedad.ClrType == typeof(string) 
                        && propiedad.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        propiedad.SetIsUnicode(false);
                        propiedad.SetMaxLength(500);
                    }
                }
            }
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<CineOferta> CinesOfertas { get; set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<CineSinUbicacion> CinesSinUbicacion { get; set; }
        public DbSet<PeliculaConConteos> PeliculasConConteos { get; set; }
    }
}

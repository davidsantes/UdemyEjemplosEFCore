using Microsoft.EntityFrameworkCore;

namespace DemoConsola
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                "Server =.; Database = EFCorePeliculasDB_01Introduccion; Integrated Security = True");
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
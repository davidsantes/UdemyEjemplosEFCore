using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
    }
}

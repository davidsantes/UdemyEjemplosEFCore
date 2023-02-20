using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos.OrderBy(g => g.Nombre).ToListAsync();
            //Orden descendiente:
            //return await context.Generos.OrderByDescending(g => g.Nombre).ToListAsync();

            //Utilización de AsNoTracking():
            //return await context.Generos.AsNoTracking().ToListAsync();
            //Utilización de AsTracking(), en caso de que se esté utilizando AsNoTracking de manera global:
            //return await context.Generos.AsTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpGet("getPrimerGeneroConLetraC")]
        public async Task<ActionResult<Genero>> GetPrimerGeneroConNombreEmpiezaConLetraC()
        {
            //Que retorne el primer elemento:
            //var genero = await context.Generos.First(g => g.Nombre.StartsWith("C"));
            //Que retorne´el primer elemento coincidente, o el primer elemento:
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Nombre.StartsWith("C"));

            if (genero is null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpGet("getFiltroPorNombre")]
        public async Task<IEnumerable<Genero>> GetFiltroPorNombre(string nombre)
        {
            return await context.Generos
                .Where(g => g.Nombre.Contains(nombre))
                .ToListAsync();

            //Todos los géneros que empiecen por cualquiera de las dos letras
            //return await context.Generos
            //    .Where(g => g.Nombre.StartsWith("C") || g.Nombre.StartsWith("A"))
            //    .ToListAsync();
        }

        [HttpGet("paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetPaginacion(int pagina = 1)
        {
            //Solo se toman estos registros a la vez
            var cantidadRegistrosPorPagina = 2;
            var generos = await context.Generos
                .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                .Take(cantidadRegistrosPorPagina)
                .ToListAsync();
            return generos;
        }
    }
}

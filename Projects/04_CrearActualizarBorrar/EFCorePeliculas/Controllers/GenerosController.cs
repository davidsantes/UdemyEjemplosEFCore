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

        [HttpPost("insertarIndividual")]
        public async Task<ActionResult> InsertarIndividual(Genero genero)
        {
            var estatus1 = context.Entry(genero).State;
            context.Add(genero);
            var estatus2 = context.Entry(genero).State;
            await context.SaveChangesAsync();
            var estatus3 = context.Entry(genero).State;
            return Ok();
        }
        
        [HttpPost("insertarMultiple")]
        public async Task<ActionResult> InsertarMultiple(Genero[] generos)
        {
            context.AddRange(generos);

            //Se podrían insertar elementos de manera individual también antes de salvar cambios
            //context.Add(new Actor());

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("modificarConectadoAgregar2")]
        public async Task<ActionResult> ModificarConectadoAgregar2(int id)
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.Nombre += " 2";
            await context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Elimina realmente el registro
        /// </summary>
        [HttpDelete("borradoNormalFisico{id:int}")]
        public async Task<ActionResult> BorradoNormalFisico(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            context.Remove(genero);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("borradoSuaveLogico/{id:int}")]
        public async Task<ActionResult> BorradoSuaveLogico(int id)
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = true;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("restaurarGeneroBorrado/{id:int}")]
        public async Task<ActionResult> RestaurarGeneroBorrado(int id)
        {
            var genero = await context.Generos.AsTracking()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = false;
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}

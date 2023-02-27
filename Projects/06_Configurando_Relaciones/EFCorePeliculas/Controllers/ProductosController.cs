using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpGet("Merchs")]
        public async Task<ActionResult<IEnumerable<Merchandising>>> GetMerchs()
        {
            //Herencia de clases - una sola tabla por cada tipo (Table per Type - TPT)
            //En el caso de tabla por tipo, produce un select más eficiente:
            return await context.Set<Merchandising>().ToListAsync();
        }

        [HttpGet("Alquileres")]
        public async Task<ActionResult<IEnumerable<PeliculaAlquilable>>> GetAlquileres()
        {
            //Herencia de clases - una sola tabla por cada tipo (Table per Type - TPT)
            //En el caso de tabla por tipo, produce un select más eficiente:
            return await context.Set<PeliculaAlquilable>().ToListAsync();
        }
    }
}

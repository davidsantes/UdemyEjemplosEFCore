using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get()
        {
            return await context.Actores
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpPost("insertarConMapeoFlexibleDeCampo")]
        public async Task<ActionResult> InsertarConMapeoFlexibleDeCampo(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("modificarConectado/{id:int}")]
        public async Task<ActionResult> ModificarConectado(ActorCreacionDTO actorCreacionDTO, int id)
        {
            var actorDB = await context.Actores.AsTracking().FirstOrDefaultAsync(a => a.Id == id);

            if (actorDB is null)
            {
                return NotFound();
            }

            //Automapper mantendrá la misma instancia de actorDB en memoria.
            //Solamente modificaremos las propiedades de actorDB y no la instancia. De esta manera se podrá
            //seguir dando seguimiento a la instancia de actor, y que el estatus del actor es modified.
            actorDB = mapper.Map(actorCreacionDTO, actorDB);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("modificarDesconectado/{id:int}")]
        public async Task<ActionResult> ModificarDesconectado(ActorCreacionDTO actorCreacionDTO, int id)
        {
            var existeActor = await context.Actores.AnyAsync(a => a.Id == id);

            if (!existeActor)
            {
                return NotFound();
            }

            var actor = mapper.Map<Actor>(actorCreacionDTO);
            actor.Id = id;

            //Permite marcar el objeto como modificado, por lo que ante el siguiente SaveChanges
            //el registro de la base de datos debe ser actualizado.
            context.Update(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

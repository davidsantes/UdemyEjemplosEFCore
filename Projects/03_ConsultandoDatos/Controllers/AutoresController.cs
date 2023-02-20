using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("getConAutoMapper")]
        public async Task<IEnumerable<ActorDTO>> GetAutomapper()
        {
            return await context.Actores
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("getConSelectAnonimo")]
        public async Task<ActionResult> GetConSelectAnonimo()
        {
            var actores = await context.Actores.Select(a =>
                new { Id = a.Id, Nombre = a.Nombre }
                ).ToListAsync();

            return Ok(actores);
        }

        [HttpGet("getConSelectADto")]
        public async Task<IEnumerable<ActorDTO>> GetConSelectADto()
        {
            var actores = await context.Actores.Select(a =>
                new ActorDTO { Id = a.Id, Nombre = a.Nombre }
                ).ToListAsync();

            return actores;
        }
    }
}
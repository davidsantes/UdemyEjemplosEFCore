using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class LogsController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LogsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Log>> Get()
        {
            var log = new Log {
                Id = Guid.NewGuid(),
                Mensaje = "Ejecutando el método LogsController.Get" 
            };
            context.Logs.Add(log);
            await context.SaveChangesAsync();
            return await context.Logs.ToListAsync();
        }
    }
}

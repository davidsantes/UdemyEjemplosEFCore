using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
            context.Logs.Add(new Log { 
                Id = Guid.NewGuid(),
                Mensaje = "Ejecutando el método GenerosController.Get" });
            await context.SaveChangesAsync();
            return await context.Generos.OrderByDescending(g => EF.Property<DateTime>(g, "FechaCreacion")).ToListAsync();
        }

        [HttpGet("GetFromProcedimientoAlmacenado/{id:int}")]
        public async Task<ActionResult<Genero>> GetFromProcedimientoAlmacenado(int id)
        {
            var generos = context.Generos
                        .FromSqlInterpolated($"EXEC Generos_ObtenerPorId {id}")
                        .IgnoreQueryFilters()
                        .AsAsyncEnumerable();

            await foreach (var genero in generos)
            {
                return genero;
            }

            return NotFound();
        }

        [HttpPost("PostFromProcedimientoAlmacenado")]
        public async Task<ActionResult> PostFromProcedimientoAlmacenado(Genero genero)
        {
            var existeGeneroConNombre = await context.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if (existeGeneroConNombre)
            {
                return BadRequest("Ya existe un género con ese nombre: " + genero.Nombre);
            }

            var outputId = new SqlParameter();
            outputId.ParameterName = "@id";
            outputId.SqlDbType = System.Data.SqlDbType.Int;
            outputId.Direction = System.Data.ParameterDirection.Output;

            await context.Database
                .ExecuteSqlRawAsync("EXEC Generos_Insertar @nombre = {0}, @id = {1} OUTPUT",
                genero.Nombre, outputId);

            var id = (int)outputId.Value;
            return Ok(id);
        }

        [HttpGet("GetFromSql_Forma1_FromSqlRaw{id:int}")]
        public async Task<ActionResult<Genero>> GetFromSql_Forma1_FromSqlRaw(int id)
        {
            var genero = await context.Generos
                        .FromSqlRaw("SeLecT * FROM Generos WHERE Identificador = {0}", id) //Se evita SQL Injection
                        .IgnoreQueryFilters()
                        .FirstOrDefaultAsync();

            if (genero is null)
            {
                return NotFound();
            }

            var fechaCreacion = context.Entry(genero).Property<DateTime>("FechaCreacion").CurrentValue;

            return Ok(new
            {
                Id = genero.Identificador,
                NoContent = genero.Nombre,
                fechaCreacion
            });
        }


        [HttpGet("GetFromSql_Forma2_FromSqlInterpolated{id:int}")]
        public async Task<ActionResult<Genero>> GetFromSql_Forma2_FromSqlInterpolated(int id)
        {

            var genero = await context.Generos
                        .FromSqlInterpolated($"SeLecT * FROM Generos WHERE Identificador = {id}")
                        .IgnoreQueryFilters()
                        .FirstOrDefaultAsync();

            if (genero is null)
            {
                return NotFound();
            }

            var fechaCreacion = context.Entry(genero).Property<DateTime>("FechaCreacion").CurrentValue;

            return Ok(new
            {
                Id = genero.Identificador,
                NoContent = genero.Nombre,
                fechaCreacion
            });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = await context.Generos
                .AsTracking()
                .FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            var fechaCreacion = context.Entry(genero).Property<DateTime>("FechaCreacion").CurrentValue;

            return Ok(new
            {
                Id = genero.Identificador,
                NoContent = genero.Nombre,
                fechaCreacion
            });
        }

        [HttpPost("CambiarEstatusEntidadManualmente")]
        public async Task<ActionResult> CambiarEstatusEntidadManualmente(Genero genero)
        {
            var existeGeneroConNombre = await context.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if (existeGeneroConNombre)
            {
                return BadRequest("Ya existe un género con ese nombre: " + genero.Nombre);
            }

            //Forma por defecto de cambiar el estado para una inserción:
            //context.Add(genero);
            
            //Forma manual:
            context.Entry(genero).State = EntityState.Added;

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("PostFromSqlExecuteSqlInterpolatedAsync")]
        public async Task<ActionResult> PostFromSqlExecuteSqlInterpolatedAsync(Genero genero)
        {
            var existeGeneroConNombre = await context.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if (existeGeneroConNombre)
            {
                return BadRequest("Ya existe un género con ese nombre: " + genero.Nombre);
            }

            //context.Add(genero);
            //context.Entry(genero).State = EntityState.Added;

            await context.Database.ExecuteSqlInterpolatedAsync($@"
            INSERT INTO Generos(Nombre)
            VALUES({genero.Nombre})");

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Genero genero)
        {
            var existeGeneroConNombre = await context.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if (existeGeneroConNombre)
            {
                return BadRequest("Ya existe un género con ese nombre: " + genero.Nombre);
            }

            //context.Add(genero);
            //context.Entry(genero).State = EntityState.Added;

            await context.Database.ExecuteSqlInterpolatedAsync($@"
            INSERT INTO Generos(Nombre)
            VALUES({genero.Nombre})");

            await context.SaveChangesAsync();

            return Ok();
        }
        
        [HttpPost("PostInsercionMultipleTransaccioPorDefecto")]
        public async Task<ActionResult> PostInsercionMultipleTransaccioPorDefecto(Genero[] generos)
        {
            context.AddRange(generos);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Genero genero)
        {
            context.Update(genero);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("agregar2")]
        public async Task<ActionResult> Agregar2(int id)
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
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

        [HttpDelete("borradoSuave/{id:int}")]
        public async Task<ActionResult> DeleteSuave(int id)
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

        [HttpPost("Restaurar/{id:int}")]
        public async Task<ActionResult> Restaurar(int id)
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

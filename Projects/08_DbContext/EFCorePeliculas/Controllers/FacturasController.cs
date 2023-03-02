using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/facturas")]
    public class FacturasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public FacturasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// En caso de que se produzca un error, al estar dentro de una transacción, no introducirá la factura con su detalle
        /// </summary>
        [HttpPost("PostConTransaccion")]
        public async Task<ActionResult> PostConTransaccion()
        {
            using var transaccion = await context.Database.BeginTransactionAsync();
            try
            {
                var factura = new Factura()
                {
                    FechaCreacion = DateTime.Now
                };

                context.Add(factura);
                await context.SaveChangesAsync();

                //Provocando un error, omitir si se quiere que se pueda introducir.
                throw new ApplicationException("Esto es una prueba");

                var facturaDetalle = new List<FacturaDetalle>()
                        {
                            new FacturaDetalle()
                            {
                                Producto = "Producto A",
                                Precio = 123,
                                FacturaId = factura.Id
                            },
                            new FacturaDetalle()
                            {
                                Producto = "Producto B",
                                Precio = 456,
                                FacturaId = factura.Id
                            }
                        };

                context.AddRange(facturaDetalle);
                await context.SaveChangesAsync();
                await transaccion.CommitAsync();
                return Ok("todo bien");
            }
            catch (Exception ex)
            {
                // Manejar excepción
                return BadRequest("Hubo un error");
            }
        }
    }
}

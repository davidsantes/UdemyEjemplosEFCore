using EFCorePeliculas.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCorePeliculas.Pruebas
{
    [TestClass]
    public class ServicioUsuarioPruebas
    {
        [TestMethod]
        public void ObtenerUsuarioId_NoTraeValorVacioONulo()
        {
            // Preparaci�n
            var servicioUsuario = new ServicioUsuario();

            // Prueba
            var resultado = servicioUsuario.ObtenerUsuarioId();

            // Verificaci�n
            Assert.AreNotEqual("", resultado);
            Assert.IsNotNull(resultado);
        }
    }
}
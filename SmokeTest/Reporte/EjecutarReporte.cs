using NUnit.Framework;

namespace SmokeTest.Principal
{
    // [TestClass]
  //  [TestFixture]
    public static class EjecutarReporte //clase para iniciar el reporte
    {
        /// <summary>
        /// Método que incializa el reporte 
        /// </summary>
        /// <param name="testContext">Almacena la información de la prueba</param>
       // [AssemblyInitialize] //se ejecuta antes de cualquier otro método
        public static void ExecuteForCreatingReportsNamespace(TestContext testContext)
        {
            Reporte.Reporte.InciarReporte();
        }
    }
}

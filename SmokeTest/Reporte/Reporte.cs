using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SmokeTest.Reporte
{
    public static class Reporte
    {
        //  private static readonly Logger logger = LogManager.GetCurrentClassLogger(); //inicializa el logg

        /// <summary>
        /// Instancia del extentReport
        /// </summary>
        private static ExtentReports ReportePruebas { get; set; }  

        //ESTANDAR
        private static string RutaCarpeta => @"C:\\Reports\reporte.html"; //ruta para almacenar el reporte

        /// <summary>
        ///  html para el reporte
        /// </summary>
        private static string HtmlReporte { get; set; } 

        /// <summary>
        /// Carpeta que va almacenar el resultado final del reporte 
        /// </summary>
        public static string ResultadoFinalReporte { get; set; }

        /// <summary>
        /// Guarda la información de las pruebas
        /// </summary>
        private static TestContext TestContext { get; set; }

        /// <summary>
        /// Argumento para el caso de prueba
        /// </summary>
        public static ExtentTest CasoPrueba { get; set; }

        private static ScenarioContext scenarioCtx { get; set; }

        /// <summary>
        /// Método para Iniciar el reporte
        /// </summary>
        public static void InciarReporte() 
        {

           // logger.Trace("Creando la configuración" + "\nIniciando reporte");// El trace trata de encontrar una parte 
                                                                             //de una función específicamente.
            DirectorioReporte(); //Directorio del reporte

            var htmlReporter = new ExtentHtmlReporter(HtmlReporte);  //objeto del html del reporte 

            ReportePruebas = new ExtentReports(); //Objeto del Reporte

            ReportePruebas.AttachReporter(htmlReporter); //adjunta el reporte en el html
        }

        /// <summary>
        /// Método para crear el directorio del reporte
        /// </summary>
        private static void DirectorioReporte()
        {
            var RutaArchivo = Path.GetFullPath(RutaCarpeta); //pasa el archivo a la carpeta 

            ResultadoFinalReporte = Path.Combine(RutaArchivo, DateTime.Now.ToString("MMdd_HHmm")); //Guarda el resultado final en una carpeta

            Directory.CreateDirectory(ResultadoFinalReporte); //crea el directorio del reporte

            HtmlReporte = $"{ResultadoFinalReporte}\\reporte.html"; //Nombre del archivo

            //logger.Trace("Ruta completa del html =>" + HtmlReporte);
        }

        /// <summary>
        /// Método para agregarle los metadatos al html del reporte
        /// </summary>
        /// <param name="testContext">almacena los datos de la prueba</param>
        public static void AgregarDatosReporte(TestContext testContext)
        {
            TestContext = testContext;
           // CasoPrueba = ReportePruebas.CreateTest(TestContext.TestName);
        }

        /// <summary>
        /// Método para enviar el tipo de mensaje pass que indica que la prueba fue exitosa
        /// </summary>
        /// <param name="oMensaje">Mensaje que se envía al pasar el estatus</param>
        public static void PruebaPass(string oMensaje)
        {
            CasoPrueba.Log(Status.Pass, oMensaje); //test en caso exitoso
        }
        public static void TestPass(string oMensaje)
        {
            CasoPrueba.Log(Status.Pass, oMensaje); //test en caso exitoso
        }

        public static void TestInfo(string oMensaje)
        {
            CasoPrueba.Log(Status.Info, oMensaje); //informacion del test
        }

        /// <summary>
        /// Método para mostrar el resultado de la prueba con el status
        /// </summary>
        public static void ResultadoPrueba()
        {
            //var status = TestContext.TestDirectory; 

           
                if (scenarioCtx.TestError == null)
            {
                CasoPrueba.Log(Status.Pass);
            }
            else if (scenarioCtx.TestError != null)
            {
                CasoPrueba.Log(Status.Fail, scenarioCtx.StepContext.StepInfo.Text);
            }

            //switch (status)
            //{
            //    case UnitTestOutcome.Failed: //la prueba se ejecuta pero tiene problemas

            //        logger.Error($"Prueba fallida =>{TestContext.FullyQualifiedTestClassName}"); //Nombre de la clase que contiene el método de prueba que se está ejecutando actualmente.                                        CasoPrueba.AddScreenCaptureFromPath(CapturaPantalla);

            //        CasoPrueba.Fail("La prueba fallo");

            //        break;

            //    case UnitTestOutcome.Inconclusive: //la prueba se completa pero no se sabe si es correcta

            //        CasoPrueba.Warning("Prueba inconclusa"); //tipo de mensaje que envía

            //        break;

            //    case UnitTestOutcome.Unknown: //indica que la prueba es desconocida

            //        CasoPrueba.Skip("Prueba desconocida");

            //        break;
            //    default:
            //        CasoPrueba.Pass("Prueba Exitosa"); //Indica que la prueba fue exitosa
            //        break;
            //}

            ReportePruebas.Flush(); // vacía los buffers o memoria temporal de salida
        }

        /// <summary>
        /// Método para enviar los tipos de errores con el log y ver su información
        /// </summary>
        /// <param name="status">Tipo de mensaje de la prueba</param>
        /// <param name="oMensaje">Mensaje correspondiente a la prueba</param>
        public static void RegistroErrores(Status status, string oMensaje) 
        {
           // logger.Info(oMensaje);
            CasoPrueba.Log(status, oMensaje);
        }
    }
}

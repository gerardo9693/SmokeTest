using AventStack.ExtentReports;
using OpenQA.Selenium;
using SmokeTest.Metodos;

namespace SmokeTest.Reporte
{
    public class ScreenShoot : BaseAplication
    {
        /// <summary>
        /// Variable para le log //ORTOGRAFIA
        /// </summary>
      //  private readonly Logger logger;

        /// <summary>
        /// Constructor para inicializar navegador y logger
        /// </summary>
        /// <param name="driver"></param>
        public ScreenShoot(IWebDriver driver): base(driver)
        {
          //  logger = LogManager.GetCurrentClassLogger(); //inicializa e instancia el logger 
         
        }

        /// <summary>
        /// Método para capturar la pantalla al terminar la prueba
        /// </summary>
        /// <returns>Retorna true o false dependiendo del resultado</returns>
        public MediaEntityModelProvider TomarCaptura(string cNombreCaptura)
        {
            //bool bandera; //ESTANDAR

            //try
            //{
                //  bandera = true; //Envía un true si la captura de pantalla se realiza

                //Screenshot 
                // var captura = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
                var captura = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;

         //   return  MediaEntityBuilder.CreateScreenCaptureFromBase64String(captura, cNombreCaptura).Build();
            
            
            
            
       //   captura.SaveAsFile($@"C:\LOG\{cNombreCaptura}.png", ScreenshotImageFormat.Png);

          return MediaEntityBuilder.CreateScreenCaptureFromBase64String(captura, cNombreCaptura).Build(); ;
            //
                //logger.Info("Prueba finalizada");
            //}
            //catch (Exception ex)
            //{
            //    bandera = false; //Envía un false si la captura de pantalla falla.

            //    //logger.Error("Error al capturar");
            //    //logger.Error(ex.Source);          //Error de fuente
            //    //logger.Error(ex.StackTrace);      //Una describe la pila de llamadas
            //    //logger.Error(ex.InnerException);  //propiedad de una excepción

            //}
            
        }
    }
}

using OpenQA.Selenium;

namespace SmokeTest.Metodos
{
    public class BaseAplication
    {
        /// <summary>
        /// Constructor para la aplicación base
        /// </summary>
        /// <param name="driver">Interfaz para el manejo del navegador</param>
        public BaseAplication(IWebDriver driver)
        {
            this.Driver = Driver;

         //   Driver.Navigate().GoToUrl(cUrl);
        }

        /// <summary>
        /// Interfaz para el manejo del navegador
        /// </summary>
        protected IWebDriver Driver { get; set; }
    }
}

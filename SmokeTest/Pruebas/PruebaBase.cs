using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SmokeTest.Metodos;

namespace SmokeTest
{
    public class PruebaBase
    {
        /// <summary>
        /// Interfaz para el manejo del navegador
        /// </summary>
        public IWebDriver Driver;

        /// <summary>
        /// instancia el ensamblado de la clase genéricos
        /// </summary>
        internal Genericos Generico { get; set; }

        [OneTimeSetUp]
        [Description("Inicia el navegador para la prueba")]
        public void IniciarNavegador()
        {
            try
            {
                Driver = new ChromeDriver(@"C:\driver\");
                Driver.Manage().Window.Maximize();	
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [OneTimeTearDown]
        [Description("Cierra el navegador al terminar la prueba")]
        public void FinalizarNavegador()
        {
            Generico = new Genericos(Driver); //instancia de la clase Genéricos
            try
            {
                Driver.Close();
                Driver.Quit();
            }
            catch
            {
                throw;
            }
        }
    }
}
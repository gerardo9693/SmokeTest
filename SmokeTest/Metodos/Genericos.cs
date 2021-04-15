using OpenQA.Selenium;

namespace SmokeTest.Metodos
{
    /// <summary>
    /// Clase para métodos genericos
    /// </summary>
    public class Genericos : BaseAplication
    {
    
        /// <summary>
        /// Método constructor de la clase Genéricos
        /// </summary>
        /// <param name="driver">Interfaz para el manejo del navegador</param>
        public Genericos(IWebDriver driver) :
            base(driver)
        {
            Driver = driver;
        }

        /// <summary>
		/// Método para abrir el navegador, redirigir a la pagina
		/// </summary>
		/// <param name="cUrl">Recibe una dirección para ingresar a la pagina.</param>
		public void AbrirNavegador(string cUrl)
        {
            try
            {
                Driver.Navigate().GoToUrl(cUrl); 
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

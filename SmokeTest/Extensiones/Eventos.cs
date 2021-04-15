using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SmokeTest.Extensiones
{
    public static class Eventos
    {
		/// <summary>
		/// Método para el tiempo de espera para objeto
		/// </summary>
		/// <param name="Driver">Interfaz para el manejo del navegador</param>
		/// <param name="by">tipo de búsqueda del objeto</param>
		/// <param name="iTiempo">cantidad de tiempo de espera</param>
		/// <returns>Retorna el objeto encontrado</returns>
		public static IWebElement FindElement(this IWebDriver Driver, By by, int iTiempo)
		{
			if (iTiempo > 0)
			{
				var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(iTiempo)); //Tiempo de espera

				return wait.Until(drv =>
				{
					try
					{
						return drv.FindElement(by);

					}
					catch (NoSuchElementException)
					{
						return null;
					}
				});
			}
			return Driver.FindElement(by);
		}

		/// <summary>
		/// Método para el tiempo de espera de los clics a un elemento de la pagina
		/// </summary>
		/// <param name="Driver">Interfaz para el manejo del navegador</param>
		/// <param name="oElemento">Objeto para dar la acción clic</param>
		/// <param name="iTiempo">Cantidad de tiempo de espera para el objeto</param>        
		public static void Click(this IWebDriver Driver, IWebElement oElemento, int iTiempo)
		{
			if (iTiempo > 0)
			{
				WebDriverWait Tiempo = new WebDriverWait(Driver, TimeSpan.FromMinutes(iTiempo)); //Tiempo de espera

				Tiempo.Until(drv =>
				{
					try
					{
						oElemento.Click();
						return oElemento;
					}
					catch (ElementClickInterceptedException)
					{
						return null;
					}
				});
			}
		}

		/// <summary>
		/// Método para el tiempo de espera de los doble clics a un elemento de la pagina
		/// </summary>
		/// <param name="Driver">Interfaz para el manejo del navegador</param>
		/// <param name="oElemento">Objeto para dar la acción doble clic</param>
		/// <param name="iTiempo">Cantidad de tiempo de espera para el objeto</param>        
		public static void DoubleClick(this IWebDriver Driver, IWebElement oElemento, int iTiempo)
		{
			if (iTiempo > 0)
			{
				WebDriverWait Tiempo = new WebDriverWait(Driver, TimeSpan.FromMinutes(iTiempo)); //Tiempo de espera

				Tiempo.Until(drv =>
				{
					try
					{
						Actions builder = new Actions(Driver); //Hace llamadas a interacciones avanzadas
						builder.DoubleClick(oElemento).Perform(); //Da doble clic a una opción del ComboBox.						
						return oElemento;
					}
					catch (ElementClickInterceptedException)
					{
						return null;
					}
				});
			}
		}
	}
}

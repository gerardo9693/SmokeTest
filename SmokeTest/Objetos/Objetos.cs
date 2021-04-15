using OpenQA.Selenium;
using SmokeTest.Extensiones;
using SmokeTest.Metodos;


namespace SmokeTest.Objetos
{
    public class ObjetosPrueba : BaseAplication
    {
        /// <summary>
        /// Método constructor de la clase
        /// </summary>
        /// <param name="driver">Interfaz para el manejo del navegador</param>
        public ObjetosPrueba(IWebDriver _driver)
            : base(_driver)
        {
            Driver = _driver;
        }

        /// <summary>
        /// Elemento input para ingresar texto
        /// </summary>
        public IWebElement cItemName => Driver.FindElement(By.XPath("/html/body/section/div/header/input"));
       
        /// <summary>
        /// Label del segundo item
        /// </summary>
        public IWebElement itenNewName => Driver.FindElement(By.XPath("/html/body/section/div/section/ul/li[2]/div"),10);

        /// <summary>
        /// Input del segundo item que se va modificar
        /// </summary>
        public IWebElement changeNameItem => Driver.FindElement(By.XPath("/html/body/section/div/section/ul/li[2]/input"), 15);

        /// <summary>
        /// boton active
        /// </summary>
        public IWebElement btnActive => Driver.FindElement(By.XPath("/html/body/section/div/footer/ul/li[2]/a"), 2);

        /// <summary>
        /// Boton para seleccionar un item
        /// </summary>
        public IWebElement RadioBtn => Driver.FindElement(By.XPath("/html/body/section/div/section/ul/li[2]/div/input"), 2);
       
        /// <summary>
        /// boton completed
        /// </summary>
        public IWebElement btnCompleted => Driver.FindElement(By.XPath("/html/body/section/div/footer/ul/li[3]/a"), 2);
        
        /// <summary>
        /// elemento para texto subrayado.
        /// </summary>
        public IWebElement textoSub => Driver.FindElement(By.XPath("/html/body/section/div/section/ul/li/div/label"), 1);
       
    }
}

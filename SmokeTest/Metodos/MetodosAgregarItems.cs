using OpenQA.Selenium;
using SmokeTest.Extensiones;
using SmokeTest.Objetos;

namespace SmokeTest.Metodos
{
    class MetodosAgregarItems : ObjetosPrueba
    {
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="driver">Interfaz para el manejo del navegador</param>
        public MetodosAgregarItems(IWebDriver driver)
            : base(driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Método para agregar items
        /// </summary>
        /// <param name="cName"></param>
        public void AgregaItem(string cName)
        {
            cItemName.SendKeys(cName + Keys.Enter );
        }

        /// <summary>
        /// Método que selecciona el segundo item y cambia el nombre
        /// </summary>
        /// <param name="cName">nuevo nombre que va tener el item</param>
        /// <returns>nombre del nuevo item</returns>
        public string CambiarNombreItem(string cName)
        {
            try
            {
                Driver.DoubleClick(itenNewName, 150);
                changeNameItem.SendKeys(Keys.Control + "a");
                changeNameItem.SendKeys(Keys.Delete);
                changeNameItem.SendKeys(cName + Keys.Enter); 
            }
            catch (System.Exception)
            {

                throw;
            }
            return cName;
        }

        /// <summary>
        /// Método para seleccionar un elemento
        /// </summary>
        public void SelectBtn()
        {
            Driver.Click(btnActive, 2);
            Driver.Click(RadioBtn,2);
            
        }

        /// <summary>
        /// Método para dar clic al boton completar
        /// </summary>
        public void CompletarItem()
        {
            Driver.Click(btnCompleted, 2);
        }
        
        /// <summary>
        /// Método que obtiene el color del elemento seleccionado.
        /// </summary>
        /// <param name="color">codigo de color del item</param>
        /// <returns>color del item</returns>
        public string ColorTexto(string color)
        {
             color=  textoSub.GetCssValue("color");

           // string hcolor = color.fromString(color).asHex();

            return color;
        }

        /// <summary>
        /// Método que obtiene el texto subrayado
        /// </summary>
        public void TextoSubrayado()
        {
            string texto = textoSub.GetCssValue("text-decoration");
        }
    }
}

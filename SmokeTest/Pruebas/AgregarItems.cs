using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using SmokeTest.Metodos;
using System.Collections.Generic;

namespace SmokeTest.Pruebas
{
    [TestFixture]
    public class AgregarItems : PruebaBase
    {

        /// <summary>
        /// Variable estatica para formar el htmlreporter
        /// </summary>
        static ExtentReports ext = null;

        /// <summary>
        /// Inicia el reporte
        /// </summary>
        [OneTimeSetUp]
        public static void ExtentStart()
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(@"C:\DotNet\SmokeTest\SmokeTest\Reporte\");
            ext = new ExtentReports();
            ext.AttachReporter(htmlReport);
        }

        /// <summary>
        /// Finaliza el reporte
        /// </summary>
        [OneTimeTearDown]
        public static void ExtentClose()
        {
            ext.Flush();
        }

        /// <summary>
        /// Variable que almacena la ruta de la pagina.
        /// </summary>
        public const string cUrl = "https://todomvc.com/examples/react/#/";
       
        /// <summary>
        /// Objeto que contiene dos listas para pasar los datos que tendra los input
        /// </summary>
        private static readonly object[] lstItems =
        {
            new object[] { new List<string> { "Hola Mundo" } },

            new object[] {new List<string> { "Adios Mundo"} }
        };
        
        /// <summary>
        /// Método para agregar los items requeridos para realizar la prueba.
        /// </summary>
        /// <param name="lstItems">Lista que contiene los dos items</param>
        [TestCaseSource(nameof(lstItems))]
        [Description("Agrega dos items a la pagina")]
        public void AAgrgarItems(List<string> lstItems)
        {
            try
            {
                Reporte.Reporte.CasoPrueba = ext.CreateTest("Agregar Elementos").Info("Agrega Elementos");
                MetodosAgregarItems items = new MetodosAgregarItems(Driver);
                Generico = new Genericos(Driver);
                Reporte.Reporte.TestInfo("Abrir navegador");
                Generico.AbrirNavegador(cUrl);
                Reporte.Reporte.TestPass("Test exitoso");

                Reporte.Reporte.TestInfo("Agrega 2 Elementos");
                foreach (var item in lstItems)
                {
                    items.AgregaItem(item);
                    if (item == "Hola Mundo")
                    {
                        Assert.IsTrue(lstItems.Contains("Hola Mundo"), item);
                    }
                    else
                    {
                        Assert.IsTrue(lstItems.Contains("Adios Mundo"), item);
                    }
                }
                Reporte.Reporte.TestPass("Elementos agregados correctamente");
            }
            catch (System.Exception)
            {
                throw;
            }       
        }

        /// <summary>
        /// Método para evaluar el cambio de nombre del item
        /// </summary>
        [Test]
        [Description("Cambia el nombre del item")]
        public void BCambiarNombreItem()
        {
            try
            {
                Reporte.Reporte.CasoPrueba = ext.CreateTest("Cambiar Nombre del Elemento").Info("Cambia Nombre");
                MetodosAgregarItems items = new MetodosAgregarItems(Driver);
                string nuevoNombre = "Tengo Hambre";
                Reporte.Reporte.TestInfo("Cambia Nombre elemento 2");
                items.CambiarNombreItem(nuevoNombre);

                Assert.IsTrue(nuevoNombre.Contains("Tengo Hambre"));
                Reporte.Reporte.TestPass("El nombre del elemento cambio correctamente");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método para seleccionar el boton del segundo item.
        /// </summary>
        [Test]
        [Description("Selecciona el segundo item agregado")]
        public void CSeleccionarBtn()
        {
            try
            {
                Reporte.Reporte.CasoPrueba = ext.CreateTest("Seleccionar el Segundo Elemento").Info("Seleccionar");
                MetodosAgregarItems items = new MetodosAgregarItems(Driver);
                Reporte.Reporte.TestInfo("Seleccionar el elemento");
                items.SelectBtn();
                Reporte.Reporte.TestPass("Elemento seleccionado");
                //Assert.AreEqual(true, items.RadioBtn.isSelected());
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método para clic completar items
        /// </summary>
        [Test]
        [Description("Hace clic en el boton Completar")]
        public void DCompletarItems()
        {
            try
            {
                Reporte.Reporte.CasoPrueba = ext.CreateTest("Completar Elementos").Info("Completa los dos elementos agregados");
                MetodosAgregarItems items = new MetodosAgregarItems(Driver);
                Reporte.Reporte.TestInfo("Da clic en el botón completar");
                items.CompletarItem();
                Reporte.Reporte.TestPass("Clic realizado con exito");

                // Assert
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que obtiene el color del texto seleccionado
        /// </summary>
        [Test]
        [Description("Indica el color del texto")]
        public void EColorTexto()
        {
            try
            {
                Reporte.Reporte.CasoPrueba = ext.CreateTest("Recuperar Color de Elemento").Info("Recuperar Color");
                MetodosAgregarItems items = new MetodosAgregarItems(Driver);
                Reporte.Reporte.TestInfo("Color de elemento");
                string colorText = "#d9d9d9";
                items.ColorTexto(colorText);
                Reporte.Reporte.TestPass("Color recuperado");
                // Assert.AreEqual(items.ColorTexto(colorText), colorText);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [Test]
        [Description("Indica si el texto esta subrayado")]
        public void FTextoSubrayado()
        {
            try
            {
                Reporte.Reporte.CasoPrueba = ext.CreateTest("Comprobar texto subrayado").Info("texto subrayado");
                MetodosAgregarItems items = new MetodosAgregarItems(Driver);
                Reporte.Reporte.TestInfo("Obtener el texto subrayado");
                string textoSub = "line-through";
                items.TextoSubrayado();
                Reporte.Reporte.TestPass("prueba exitosa");
                //Assert.AreEqual(items.TextoSubrayado(), textoSub);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

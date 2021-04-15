using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SmokeTest.Configuracion
{
  //  [TechTalk.SpecFlow.Binding]

   // [TestFixture]
    public class ReportManager
    {

       //static ExtentReports ext = null;

       // [OneTimeSetUp]
       // public static void ExtentStart()
       // {
       //     ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(@"C:\DotNet\SmokeTest\SmokeTest\Reporte\");
       //     ext = new ExtentReports();
       //     ext.AttachReporter(htmlReport);
       // }

       // [OneTimeTearDown]
       // public static void ExtentClose()
       // {
       //     ext.Flush();
       // }


        static AventStack.ExtentReports.ExtentReports extent; 
        static AventStack.ExtentReports.ExtentTest feature; 
         AventStack.ExtentReports.ExtentTest scenario, step; 

        static string cRutaReport = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");



        [OneTimeSetUp]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(cRutaReport);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);

        }


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}

using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class TesteGit
    {
        public IWebDriver driver;
        private IJavaScriptExecutor js;

        // Método para gerar uma data válida de forma aleatória
        public DateTime GerarData()
        {
            Random rnd = new Random();

            int ano = rnd.Next(1950, 2017);
            int mes = rnd.Next(1, 13);

            int ultimoDia =
                DateTime.DaysInMonth(ano, mes);

            int dia =
                rnd.Next(1, ultimoDia + 1);

            return new DateTime(ano, mes, dia);
        }

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignora erros ao fechar o navegador.
            }
        }

        [Test]
        public void GeraData()
        {
            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("https://www.google.com.br");

            Thread.Sleep(2000);

            DateTime dataGerada = GerarData();

            js.ExecuteScript(
                "alert('Data gerada: " +
                dataGerada.ToString("dd/MM/yyyy") +
                "');"
            );

            Thread.Sleep(3000);
        }
    }
}
using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class NomeDoProjeto
    {
        public IWebDriver driver;

        private string baseURL;

        IJavaScriptExecutor js;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            baseURL = "http://www.seusite.com.br";
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
                // Ignora erros caso não seja possível fechar o navegador.
            }
        }

        [Test]
        public void NomeDoTeste()
        {
            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl(baseURL);

            Thread.Sleep(1000);

            // Rola a página 300 pixels para baixo.
            js.ExecuteScript(
                "window.scrollBy(0, 300);"
            );

            Thread.Sleep(1500);

            // Rola a página 300 pixels para cima.
            js.ExecuteScript(
                "window.scrollBy(0, -300);"
            );

            Thread.Sleep(2000);
        }
    }
}
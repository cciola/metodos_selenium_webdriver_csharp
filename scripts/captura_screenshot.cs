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

        public string screenshotsPasta;

        int contador = 1;

        // Método responsável pela captura do screenshot.
        public void Screenshot(
            IWebDriver driver,
            string screenshotsPasta)
        {
            ITakesScreenshot camera =
                driver as ITakesScreenshot;

            Screenshot foto =
                camera.GetScreenshot();

            foto.SaveAsFile(
                screenshotsPasta,
                ScreenshotImageFormat.Png
            );
        }

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            baseURL = "https://www.google.com.br";

            screenshotsPasta =
                @"C:\Selenium\Evidencias\";
        }

        // Método que gera o nome do arquivo
        // e realiza a captura.
        public void capturaImagem()
        {
            Screenshot(
                driver,
                screenshotsPasta +
                "Imagem_" +
                contador++ +
                ".png"
            );

            Thread.Sleep(500);
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
                // Ignora erros caso não seja possível
                // fechar o navegador.
            }
        }

        [Test]
        public void NomeDoTeste()
        {
            driver.Navigate().GoToUrl(
                baseURL + "/intl/pt-BR/about/"
            );

            Thread.Sleep(1000);

            capturaImagem();

            Thread.Sleep(1000);
        }
    }
}
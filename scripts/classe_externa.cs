using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CadastroUsuario;

namespace SeleniumTests
{
    [TestFixture]
    public class Testes
    {
        public IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            baseURL = "http://www.url.com.br";
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
        public void NomeDoTeste()
        {
            GeraCPF gerador = new GeraCPF();

            driver.Navigate().GoToUrl(baseURL);

            Thread.Sleep(2000);

            driver.FindElement(By.Id("lst-ib"))
                .Click();

            driver.FindElement(By.Id("lst-ib"))
                .SendKeys(gerador.GerarCpf());

            Thread.Sleep(2000);
        }
    }
}
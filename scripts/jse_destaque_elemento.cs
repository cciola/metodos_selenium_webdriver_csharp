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
        private string baseURL;

        IJavaScriptExecutor js;

        public string pesquisa = "teste de software";

        public void destaque(IWebElement elemento)
        {
            IJavaScriptExecutor js;
            js = (IJavaScriptExecutor)driver;

            js.ExecuteScript(
                "arguments[0].setAttribute('style', arguments[1]);",
                elemento,
                "color: yellow; border: 4px solid yellow;"
            );

            Thread.Sleep(500);
        }

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            baseURL = "https://www.google.com.br";
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
        public void GerarCPF()
        {
            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl(baseURL);

            Thread.Sleep(2000);

            destaque(
                driver.FindElement(
                    By.Id("sb_ifc0")
                )
            );

            driver.FindElement(By.Id("lst-ib")).Click();

            driver.FindElement(By.Id("lst-ib"))
                  .SendKeys(pesquisa);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("lst-ib"))
                  .SendKeys(Keys.Enter);

            Thread.Sleep(2000);
        }
    }
}
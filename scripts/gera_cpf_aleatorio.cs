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
        private IJavaScriptExecutor js;

        // Método para gerar CPF válido de forma randômica
        public string GerarCpf()
        {
            int soma = 0;
            int resto = 0;

            int[] multiplicador1 =
                new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 =
                new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();

            string semente =
                rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
            {
                soma +=
                    int.Parse(semente[i].ToString()) *
                    multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente += resto;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma +=
                    int.Parse(semente[i].ToString()) *
                    multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente += resto;

            return semente;
        }

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
            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl(baseURL);

            Thread.Sleep(1000);

            js.ExecuteScript(
                "alert('CPF gerado: " + GerarCpf() + "');"
            );

            Thread.Sleep(3000);
        }
    }
}
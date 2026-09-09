# Exibir destaque de elemento com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para destacar visualmente um elemento da página durante a execução de um teste automatizado.

O destaque pode ser útil principalmente durante a execução dos testes em modo visual, facilitando a identificação do elemento que está sendo manipulado pela automação.

## 📋 Pré-requisitos

Para executar o exemplo, é necessário criar um **Unit Test Project** e adicionar as bibliotecas necessárias para o NUnit e Selenium WebDriver.

As referências utilizadas originalmente neste exemplo incluem:

```text
NUnit

NUnit 3 - NUnit Project Loader Extension
NUnit 3 - NUnit V2 Framework Driver Extension
NUnit 3 - NUnit V2 Result Writer Extension
NUnit 3 - Team City Event Listener Extension
NUnit 3 - Visual Studio Project Loader Extension

NUnit Console Runner Version 3 (No Extensions)
NUnit Console Runner Version 3 With Extensions
NUnit Console Version 3

NUnit Test Adapter for VS2012, VS2013 and VS2015

Selenium WebDriver
Selenium WebDriver Support Classes
Selenium.Support

Selenium.WebDriver.ChromeDriver
Selenium.WebDriver.IEDriver
Selenium.WebDriver.Firefox
```

Os drivers específicos de navegador são necessários de acordo com o navegador que será utilizado:

* `Selenium.WebDriver.ChromeDriver` — Google Chrome
* `Selenium.WebDriver.IEDriver` — Internet Explorer
* `Selenium.WebDriver.Firefox` — Mozilla Firefox

> **Observação:** as referências acima correspondem ao ambiente em que o exemplo foi originalmente desenvolvido. Em versões atuais do Selenium, NUnit e Visual Studio, a instalação e configuração dos pacotes pode ser diferente.

## 💡 Como funciona

O Selenium disponibiliza a interface `IJavaScriptExecutor`, que permite executar comandos JavaScript diretamente no navegador controlado pelo WebDriver.

Primeiro, declare o objeto `IJavaScriptExecutor` na classe de teste:

```csharp
[TestFixture]
public class NomeDoProjeto
{
    public IWebDriver driver;
    private string baseURL;

    IJavaScriptExecutor js;

    public string pesquisa = "teste de software";
}
```

Em seguida, crie um método responsável por aplicar o destaque ao elemento:

```csharp
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
```

Nesse método:

* `IJavaScriptExecutor` permite executar JavaScript;
* `IWebElement elemento` recebe o elemento que será destacado;
* `ExecuteScript()` executa o código JavaScript no navegador;
* `arguments[0]` representa o elemento recebido pelo método;
* `arguments[1]` representa o estilo que será aplicado;
* `color: yellow` altera a cor do texto;
* `border: 4px solid yellow` adiciona uma borda amarela ao elemento;
* `Thread.Sleep(500)` mantém o destaque visível por alguns instantes.

## ▶️ Inicializando o JavascriptExecutor

Antes de utilizar o JavascriptExecutor no teste, faça a conversão do `driver`:

```csharp
js = (IJavaScriptExecutor)driver;
```

Essa conversão permite que o WebDriver seja utilizado para executar comandos JavaScript.

## 🧪 Utilizando o método no teste

Depois que o método `destaque()` estiver implementado, basta localizar o elemento desejado e enviá-lo como parâmetro:

```csharp
destaque(
    driver.FindElement(
        By.Id("informe-o-ID-do-elemento")
    )
);
```

Nesse caso, o Selenium localiza o elemento pelo seu `id` e o método `destaque()` aplica o estilo definido.

## 🔎 Exemplo

O exemplo abaixo:

1. Abre o Google Chrome;
2. Maximiza a janela;
3. Acessa o Google;
4. Localiza o campo de pesquisa;
5. Destaca o campo;
6. Digita o texto `teste de software`;
7. Pressiona `Enter`;
8. Realiza a pesquisa.

### Código completo

```csharp
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
```

> **Atenção:** o exemplo acima foi desenvolvido originalmente utilizando os elementos e IDs disponíveis no Google na época em que o código foi criado. Como a estrutura HTML de sites pode mudar, os IDs `sb_ifc0` e `lst-ib` podem não estar disponíveis atualmente. Nesse caso, substitua-os pelo identificador correspondente ao elemento existente na página.

## 📝 Resultado esperado

Durante a execução, o campo de pesquisa localizado pelo Selenium recebe o seguinte estilo:

```css
color: yellow;
border: 4px solid yellow;
```

Visualmente, o elemento fica destacado na página, permitindo acompanhar com mais facilidade qual elemento está sendo manipulado pelo teste.

## ⚡ Quando utilizar

O destaque de elementos pode ser útil para:

* Depuração de testes automatizados;
* Demonstrações de automação;
* Apresentações;
* Identificação visual dos elementos durante a execução;
* Investigação de problemas em scripts Selenium.

Para uma suíte de testes automatizados em execução contínua, esse recurso normalmente não é necessário, pois seu principal objetivo é auxiliar na **visualização e depuração** da automação.

---

## 🎯 Objetivo do repositório

Este exemplo faz parte da série de exemplos de **Selenium WebDriver com C#** deste repositório.

Como o estudo da ferramenta é incremental, novos exemplos podem ser adicionados conforme novos recursos forem explorados.

A ideia é manter os códigos como uma **referência rápida** para funcionalidades que podem ser reutilizadas em diferentes scripts de automação.

---

## 🤝 Contribuições

Sugestões, melhorias e novos exemplos são bem-vindos! Caso você tenha alguma dúvida, sugestão ou queira contribuir com o projeto, fique à vontade para entrar em contato.

---

## 📌 Observação

Este repositório foi criado inicialmente como material de estudo e referência pessoal durante o aprendizado do Selenium WebDriver com C#. Os exemplos aqui apresentados representam funcionalidades que foram exploradas e utilizadas em automações, podendo ser adaptados conforme a necessidade de cada projeto.

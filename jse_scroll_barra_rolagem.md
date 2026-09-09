# Executar scroll da barra de rolagem com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para controlar a barra de rolagem de uma página por meio de JavaScript.

A técnica permite movimentar a página vertical ou horizontalmente durante a execução de um teste automatizado.

Neste exemplo, a página é:

1. Acessada pelo Selenium WebDriver;
2. Rolada para baixo;
3. Rolada novamente para cima.

## 📋 Pré-requisitos

Para executar o exemplo, é necessário criar um **Unit Test Project** e adicionar as bibliotecas necessárias para o NUnit e Selenium WebDriver.

As referências utilizadas originalmente neste exemplo incluem:

```text id="x8j2m4"
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

Os drivers específicos de navegador são necessários de acordo com o navegador utilizado:

* `Selenium.WebDriver.ChromeDriver` — Google Chrome
* `Selenium.WebDriver.IEDriver` — Internet Explorer
* `Selenium.WebDriver.Firefox` — Mozilla Firefox

> **Observação:** as referências acima correspondem ao ambiente em que o exemplo foi originalmente desenvolvido. Em versões atuais do Selenium, NUnit e Visual Studio, a instalação e configuração dos pacotes pode ser diferente.

## 💡 O que é o JavascriptExecutor?

O Selenium WebDriver disponibiliza a interface `IJavaScriptExecutor`, que permite executar comandos JavaScript diretamente no navegador controlado pelo WebDriver.

Primeiro, declare o objeto na classe de teste:

```csharp id="n4f7w2"
[TestFixture]
public class NomeDoProjeto
{
    public IWebDriver driver;

    IJavaScriptExecutor js;
}
```

Antes de utilizar o JavascriptExecutor, faça a conversão do `driver`:

```csharp id="p3v9k1"
js = (IJavaScriptExecutor)driver;
```

A partir desse momento, o objeto `js` poderá ser utilizado para executar comandos JavaScript no navegador.

## 📜 Utilizando window.scrollBy()

Para movimentar a página, podemos utilizar o método JavaScript:

```javascript id="m8q2x6"
window.scrollBy(x, y)
```

Os parâmetros representam o deslocamento em pixels:

* `x` — deslocamento horizontal;
* `y` — deslocamento vertical.

Por exemplo:

```javascript id="w5r1t8"
window.scrollBy(0, 300)
```

significa:

* Não movimentar horizontalmente (`0`);
* Descer **300 pixels** verticalmente (`300`).

Para subir 300 pixels:

```javascript id="k7d4p2"
window.scrollBy(0, -300)
```

O valor negativo faz com que a página seja movimentada para cima.

## ⬇️ Rolando a página para baixo

No Selenium, podemos executar o JavaScript da seguinte forma:

```csharp id="z2f6h9"
js.ExecuteScript(
    "window.scrollBy(0, 300);"
);
```

Nesse caso, a página será deslocada **300 pixels para baixo**.

## ⬆️ Rolando a página para cima

Para retornar 300 pixels:

```csharp id="q9c3v7"
js.ExecuteScript(
    "window.scrollBy(0, -300);"
);
```

Como o valor vertical é negativo, a página será deslocada **300 pixels para cima**.

## 🧪 Exemplo de utilização

O fluxo básico do teste é:

1. Inicializar o navegador;
2. Acessar a URL desejada;
3. Inicializar o JavascriptExecutor;
4. Rolar a página para baixo;
5. Aguardar alguns instantes;
6. Rolar a página para cima;
7. Finalizar o navegador.

O código principal fica desta forma:

```csharp id="s6y1p4"
js = (IJavaScriptExecutor)driver;

driver.Navigate().GoToUrl(baseURL);

Thread.Sleep(1000);

js.ExecuteScript(
    "window.scrollBy(0, 300);"
);

Thread.Sleep(1500);

js.ExecuteScript(
    "window.scrollBy(0, -300);"
);

Thread.Sleep(2000);
```

## 🔎 Código completo

Copie o código abaixo, informe a URL da aplicação que deseja utilizar e execute o teste.

```csharp id="d8m5q3"
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
```

## 🎯 Resultado esperado

Durante a execução, o navegador acessará a página configurada em `baseURL`.

Em seguida:

```text id="v4n8x2"
Página inicial
     │
     │
     ▼
  Scroll ↓
  300 pixels
     │
     │
     ▼
Página deslocada
     │
     │
     ▲
  Scroll ↑
  300 pixels
     │
     │
     ▼
Retorno à posição anterior
```

Assim, será possível visualizar a página sendo movimentada para baixo e, posteriormente, retornando para cima.

## 🧭 Outras formas de utilizar o scroll

O JavascriptExecutor também pode ser utilizado para realizar outros tipos de movimentação.

### Rolar até o final da página

```csharp id="b3q7m1"
js.ExecuteScript(
    "window.scrollTo(0, document.body.scrollHeight);"
);
```

Esse comando posiciona a página no final do documento.

### Rolar até o início da página

```csharp id="h6p2w9"
js.ExecuteScript(
    "window.scrollTo(0, 0);"
);
```

Esse comando retorna a página para o início.

### Rolar até um elemento específico

Uma alternativa bastante útil em automação é fazer o scroll até determinado elemento:

```csharp id="r5k8c4"
IWebElement elemento = driver.FindElement(
    By.Id("id-do-elemento")
);

js.ExecuteScript(
    "arguments[0].scrollIntoView();",
    elemento
);
```

Nesse caso, o JavaScript recebe o elemento encontrado pelo Selenium e utiliza `scrollIntoView()` para posicioná-lo na área visível do navegador.

---

## 🎯 Quando utilizar

O JavascriptExecutor pode ser útil para:

* Controlar a posição da página;
* Rolar páginas longas;
* Acessar elementos que estão fora da área visível;
* Rolar até um elemento específico;
* Auxiliar na automação de páginas com comportamentos específicos de JavaScript;
* Investigar problemas relacionados à posição dos elementos durante a execução dos testes.

Sempre que possível, porém, é interessante avaliar se o próprio Selenium já oferece uma forma adequada de realizar a interação necessária.

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

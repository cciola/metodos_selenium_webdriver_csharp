# Exibir popup com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para executar JavaScript no navegador e exibir um **popup (`alert`)** durante a execução de um teste automatizado.

O exemplo apresenta duas possibilidades:

* Exibir um popup contendo um **texto fixo**;
* Exibir um popup contendo um **texto concatenado com o valor de uma variável**.

## 📋 Pré-requisitos

Para executar o exemplo, é necessário criar um **Unit Test Project** e adicionar as bibliotecas necessárias para o NUnit e Selenium WebDriver.

As referências utilizadas originalmente neste exemplo incluem:

```text id="f8q0qv"
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

```csharp id="4s9d4b"
[TestFixture]
public class NomeDoProjeto
{
    public IWebDriver driver;

    IJavaScriptExecutor js;
}
```

Antes de utilizar o JavascriptExecutor, faça a conversão do `driver`:

```csharp id="r1j4wz"
js = (IJavaScriptExecutor)driver;
```

A partir desse momento, o objeto `js` poderá ser utilizado para executar JavaScript na página.

## 💬 Exibindo um popup com texto fixo

Para exibir um popup utilizando JavaScript, podemos utilizar a função `alert()`:

```csharp id="8lq0k5"
js.ExecuteScript(
    "alert('Script de teste finalizado com sucesso!');"
);
```

O navegador exibirá uma caixa de diálogo semelhante a:

```text id="f0r9qk"
┌──────────────────────────────────────┐
│                                      │
│  Script de teste finalizado com      │
│  sucesso!                            │
│                                      │
│                         [ OK ]       │
└──────────────────────────────────────┘
```

Esse comando executa o JavaScript:

```javascript id="b5l8j2"
alert('Script de teste finalizado com sucesso!');
```

## 🔤 Exibindo um popup com uma variável

Também é possível utilizar uma variável C# para montar o texto que será exibido no popup.

Por exemplo:

```csharp id="q4x8sn"
public string variavel = "Carol";
```

O valor da variável pode ser concatenado ao JavaScript:

```csharp id="9y5v0e"
js.ExecuteScript(
    "alert('Valor da variavel: " + variavel + "');"
);
```

Nesse caso, o popup exibirá:

```text id="2q9w1k"
Valor da variavel: Carol
```

### Exemplo utilizando um dado gerado pelo teste

O mesmo conceito pode ser utilizado para exibir informações geradas durante a execução do teste.

Por exemplo:

```csharp id="8g7n3p"
js.ExecuteScript(
    "alert('CPF gerado: " + GerarCpf() + "');"
);
```

Nesse caso, o resultado da função `GerarCpf()` será concatenado à mensagem exibida no popup.

## 🧪 Exemplo 1 — Texto fixo

O código abaixo:

1. Inicializa o Chrome;
2. Cria uma instância do JavascriptExecutor;
3. Executa um `alert()` com um texto fixo;
4. Mantém o popup aberto por alguns segundos;
5. Encerra o navegador.

```csharp id="c2k8xv"
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

        IJavaScriptExecutor js;

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
                // Ignora erros caso não seja possível fechar o navegador.
            }
        }

        [Test]
        public void NomeDoTeste()
        {
            js = (IJavaScriptExecutor)driver;

            js.ExecuteScript(
                "alert('Script de teste finalizado com sucesso!');"
            );

            Thread.Sleep(3000);
        }
    }
}
```

## 🧪 Exemplo 2 — Texto + variável

Neste exemplo, uma variável C# é utilizada para complementar o texto do popup.

```csharp id="w6s1pr"
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

        IJavaScriptExecutor js;

        public string variavel = "Carol";

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
                // Ignora erros caso não seja possível fechar o navegador.
            }
        }

        [Test]
        public void NomeDoTeste()
        {
            js = (IJavaScriptExecutor)driver;

            js.ExecuteScript(
                "alert('Valor da variavel: " + variavel + "');"
            );

            Thread.Sleep(3000);
        }
    }
}
```

## 🎯 Resultado esperado

Nos dois exemplos, o navegador é iniciado e um popup JavaScript é exibido.

### Texto fixo

```text id="j5x7kq"
Script de teste finalizado com sucesso!
```

### Texto + variável

Considerando:

```csharp id="u2p8nc"
public string variavel = "Carol";
```

O resultado será:

```text id="b7q4mz"
Valor da variavel: Carol
```

## ⚠️ Interagindo com o popup

O `alert()` utilizado neste exemplo é um **JavaScript Alert** do navegador.

Quando um alert está aberto, o navegador fica aguardando uma ação do usuário. Em uma automação real, normalmente será necessário tratá-lo utilizando os recursos de `IAlert` do Selenium.

Por exemplo, para aceitar o popup:

```csharp id="r8m3qt"
IAlert alert = driver.SwitchTo().Alert();

alert.Accept();
```

Para obter o texto exibido:

```csharp id="p1v6ks"
IAlert alert = driver.SwitchTo().Alert();

string mensagem = alert.Text;
```

Isso permite transformar o popup em parte de uma validação automatizada, em vez de apenas utilizá-lo para visualização.

## 🎯 Quando utilizar

O JavascriptExecutor pode ser útil para:

* Executar JavaScript durante a automação;
* Exibir informações durante a execução;
* Auxiliar na depuração de testes;
* Demonstrar valores gerados durante o teste;
* Interagir com funcionalidades legadas que dependem de JavaScript;
* Apoiar investigações de comportamento da aplicação.

Para testes automatizados, entretanto, um `alert()` normalmente deve ser utilizado com uma finalidade específica, como **validação ou depuração**, e não apenas como mecanismo de espera.

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

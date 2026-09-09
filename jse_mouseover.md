# Executar mouseover (hover) com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para executar a ação de **mouseover (hover)** sobre um elemento da página.

A técnica pode ser utilizada em situações nas quais um menu ou outro elemento da interface apresenta informações adicionais, como **submenus, opções ou menus dropdown**, quando o cursor do mouse é posicionado sobre ele.

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

Os drivers específicos de navegador são necessários de acordo com o navegador utilizado:

* `Selenium.WebDriver.ChromeDriver` — Google Chrome
* `Selenium.WebDriver.IEDriver` — Internet Explorer
* `Selenium.WebDriver.Firefox` — Mozilla Firefox

> **Observação:** as referências acima correspondem ao ambiente em que o exemplo foi originalmente desenvolvido. Em versões atuais do Selenium, NUnit e Visual Studio, a instalação e configuração dos pacotes pode ser diferente.

## 💡 O que é mouseover (hover)?

O **mouseover**, também conhecido como **hover**, ocorre quando o cursor do mouse é posicionado sobre determinado elemento da página.

Um exemplo comum é um menu de navegação que exibe opções adicionais quando o usuário posiciona o mouse sobre ele:

```text
MENU PRINCIPAL
       ↓
┌─────────────────────┐
│ Opção 1             │
│ Opção 2             │
│ Opção 3             │
└─────────────────────┘
```

Durante uma automação, podemos precisar reproduzir esse comportamento para verificar se o submenu ou outra informação é exibida corretamente.

## 🟨 Utilizando JavascriptExecutor

O Selenium WebDriver disponibiliza a interface `IJavaScriptExecutor`, que permite executar comandos JavaScript diretamente no navegador.

Primeiro, declare o objeto na classe de teste:

```csharp
[TestFixture]
public class NomeDoProjeto
{
    public IWebDriver driver;

    IJavaScriptExecutor js;
}
```

Antes de executar o JavaScript, faça a conversão do `driver`:

```csharp
js = (IJavaScriptExecutor)driver;
```

Essa conversão permite utilizar o objeto `js` para executar scripts no navegador.

## 🖱️ Executando o mouseover

O elemento que receberá o mouseover pode ser localizado normalmente utilizando os recursos do Selenium:

```csharp
IWebElement menu = driver.FindElement(
    By.LinkText("MENU PRINCIPAL")
);
```

Em seguida, o evento `onmouseover` pode ser executado utilizando o JavascriptExecutor:

```csharp
js.ExecuteScript(
    "arguments[0].onmouseover()",
    menu
);
```

Nesse código:

* `IWebElement menu` representa o elemento sobre o qual será realizado o hover;
* `FindElement()` localiza o elemento na página;
* `By.LinkText()` localiza um link pelo seu texto;
* `arguments[0]` representa o elemento enviado ao JavaScript;
* `onmouseover()` executa o evento de mouseover do elemento.

Após executar o evento, o teste pode aguardar alguns instantes para permitir a visualização do resultado:

```csharp
Thread.Sleep(3000);
```

## 🧪 Exemplo de utilização

O fluxo básico do teste é:

1. Inicializar o navegador;
2. Acessar a página desejada;
3. Localizar o menu;
4. Executar o evento `mouseover`;
5. Aguardar a exibição do submenu;
6. Continuar a execução do teste.

O código principal fica desta forma:

```csharp
js = (IJavaScriptExecutor)driver;

driver.Navigate().GoToUrl(baseURL);

Thread.Sleep(1000);

IWebElement menu = driver.FindElement(
    By.LinkText("NomeDoMenu")
);

js.ExecuteScript(
    "arguments[0].onmouseover()",
    menu
);

Thread.Sleep(3000);
```

Substitua `NomeDoMenu` pelo texto correspondente ao menu da aplicação que deseja manipular.

## 🔎 Código completo

Copie o código abaixo, ajuste a URL e o nome do menu de acordo com a aplicação que será utilizada e execute o teste.

```csharp
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

            IWebElement menu = driver.FindElement(
                By.LinkText("NomeDoMenu")
            );

            js.ExecuteScript(
                "arguments[0].onmouseover()",
                menu
            );

            Thread.Sleep(3000);
        }
    }
}
```

## 🎯 Resultado esperado

Ao executar o teste, o navegador:

1. Acessa a página configurada em `baseURL`;
2. Localiza o menu informado;
3. Executa o evento `mouseover`;
4. Exibe o submenu ou conteúdo associado ao evento.

Em uma aplicação com menu dropdown, por exemplo:

```text
Antes do mouseover:

┌─────────────────────┐
│ MENU PRINCIPAL      │
└─────────────────────┘


Depois do mouseover:

┌─────────────────────┐
│ MENU PRINCIPAL      │
├─────────────────────┤
│ Opção 1             │
│ Opção 2             │
│ Opção 3             │
└─────────────────────┘
```

## ⚠️ Observação importante

Este exemplo utiliza diretamente o evento JavaScript:

```javascript
arguments[0].onmouseover()
```

Isso **não é exatamente a mesma coisa que mover fisicamente o cursor do mouse até o elemento**. O código dispara o evento `onmouseover` associado ao elemento.

Em aplicações modernas, o comportamento de menus pode ser implementado por outros mecanismos, como listeners JavaScript, CSS `:hover` ou frameworks de frontend. Nesses casos, a abordagem mais adequada pode ser utilizar os recursos de interação do próprio Selenium, como `Actions`, por exemplo:

```csharp
Actions actions = new Actions(driver);

actions.MoveToElement(menu).Perform();
```

Portanto, o JavascriptExecutor é uma alternativa útil quando é necessário executar diretamente um comportamento JavaScript específico.

## 🎯 Quando utilizar

Essa técnica pode ser útil para:

* Interagir com menus dropdown;
* Acionar eventos JavaScript específicos;
* Investigar comportamentos da interface;
* Auxiliar na depuração de testes;
* Automatizar aplicações legadas que dependem de eventos JavaScript.

Para aplicações modernas, recomenda-se avaliar primeiro se a interação pode ser realizada diretamente pelas APIs de interação do Selenium, utilizando `Actions` e outros recursos nativos do WebDriver.

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

# Captura de screenshot

Este exemplo demonstra como utilizar o **Selenium WebDriver** para capturar screenshots durante a execução de testes automatizados.

A implementação permite:

* Capturar a tela atual do navegador;
* Definir a pasta onde os screenshots serão armazenados;
* Definir um nome para os arquivos;
* Numerar automaticamente os screenshots;
* Evitar que capturas sucessivas utilizem o mesmo nome de arquivo.

Esse recurso pode ser especialmente útil para **evidências de testes**, **depuração** e investigação de falhas durante a execução da automação.

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

## 📸 Como funciona a captura de screenshot

O Selenium disponibiliza a interface `ITakesScreenshot`, que permite solicitar ao navegador uma captura da tela atual.

Primeiro, declare as variáveis necessárias na classe de teste:

```csharp
[TestFixture]
public class NomeDoProjeto
{
    public IWebDriver driver;

    private string baseURL;

    public string screenshotsPasta;

    int contador = 1;
}
```

Cada variável possui uma finalidade:

* `IWebDriver driver` — representa o navegador controlado pelo Selenium;
* `baseURL` — armazena a URL base da aplicação;
* `screenshotsPasta` — armazena o diretório onde os screenshots serão salvos;
* `contador` — controla a numeração dos arquivos gerados.

## 🖼️ Criando o método de captura

O método responsável pela captura pode ser implementado da seguinte forma:

```csharp
public void Screenshot(
    IWebDriver driver,
    string screenshotsPasta)
{
    ITakesScreenshot camera = driver as ITakesScreenshot;

    Screenshot foto = camera.GetScreenshot();

    foto.SaveAsFile(
        screenshotsPasta,
        ScreenshotImageFormat.Png
    );
}
```

### Entendendo o código

#### `ITakesScreenshot`

```csharp
ITakesScreenshot camera = driver as ITakesScreenshot;
```

Aqui, o `driver` é convertido para `ITakesScreenshot`, permitindo utilizar os recursos de captura de tela disponibilizados pelo Selenium.

#### `GetScreenshot()`

```csharp
Screenshot foto = camera.GetScreenshot();
```

Essa instrução solicita ao WebDriver uma captura da tela atual e armazena o resultado na variável `foto`.

#### `SaveAsFile()`

```csharp
foto.SaveAsFile(
    screenshotsPasta,
    ScreenshotImageFormat.Png
);
```

Esse método salva a captura no caminho informado.

O segundo parâmetro define o formato da imagem:

```csharp
ScreenshotImageFormat.Png
```

Neste exemplo, os arquivos serão salvos no formato **PNG**.

## 📁 Definindo a pasta de evidências

O diretório onde os screenshots serão armazenados pode ser configurado no método `[SetUp]`:

```csharp
[SetUp]
public void SetupTest()
{
    driver = new ChromeDriver();

    driver.Manage().Window.Maximize();

    baseURL = "https://www.google.com.br";

    screenshotsPasta =
        @"C:\Users\cciola\Documents\Visual Studio 2013\Projects\TesteGit\Evidencias\";
}
```

Nesse exemplo:

```csharp
driver = new ChromeDriver();
```

inicializa o navegador Chrome.

```csharp
driver.Manage().Window.Maximize();
```

maximiza a janela do navegador.

```csharp
baseURL = "https://www.google.com.br";
```

define a URL base utilizada pelo teste.

E:

```csharp
screenshotsPasta =
    @"C:\Users\cciola\Documents\Visual Studio 2013\Projects\TesteGit\Evidencias\";
```

define o diretório onde os screenshots serão armazenados.

> **Importante:** a pasta informada deve existir antes da execução do teste. Em uma implementação mais robusta, o código pode verificar a existência do diretório e criá-lo automaticamente quando necessário.

## 🔢 Gerando nomes numerados

Para gerar automaticamente o nome dos arquivos, podemos criar um método específico:

```csharp
public void capturaImagem()
{
    Screenshot(
        driver,
        screenshotsPasta + "Imagem_" + contador++ + ".png"
    );

    Thread.Sleep(500);
}
```

O trecho:

```csharp
"Imagem_" + contador++ + ".png"
```

gera nomes sequenciais, por exemplo:

```text
Imagem_1.png
Imagem_2.png
Imagem_3.png
Imagem_4.png
```

O operador `++` incrementa o valor do contador após sua utilização.

Assim, cada nova chamada do método `capturaImagem()` gera um nome diferente.

## 🧪 Utilizando a captura durante o teste

Depois que os métodos forem implementados, basta chamar:

```csharp
capturaImagem();
```

no ponto em que deseja obter a evidência.

Por exemplo:

```csharp
driver.Navigate().GoToUrl(
    baseURL + "/intl/pt-BR/about/"
);

Thread.Sleep(1000);

capturaImagem();
```

Nesse caso, o screenshot será capturado após o carregamento da página.

## 🔎 Código completo

Copie o código abaixo, ajuste o diretório de evidências e execute o teste.

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
```

## 🎯 Resultado esperado

Durante a execução, o teste:

1. Inicializa o Chrome;
2. Maximiza a janela;
3. Acessa a URL configurada;
4. Aguarda o carregamento da página;
5. Captura um screenshot;
6. Salva a imagem na pasta configurada.

Por exemplo:

```text
C:\Selenium\Evidencias\
│
├── Imagem_1.png
├── Imagem_2.png
├── Imagem_3.png
└── Imagem_4.png
```

Cada chamada ao método `capturaImagem()` gera uma nova imagem numerada.

## 📌 Capturando evidências em diferentes etapas

Uma das vantagens dessa abordagem é poder realizar screenshots em diferentes momentos do teste.

Por exemplo:

```csharp
// Evidência após abrir a página.
capturaImagem();

// Executa uma ação.
driver.FindElement(By.Id("campo")).Click();

// Evidência após a ação.
capturaImagem();

// Executa outra ação.
driver.FindElement(By.Id("botao")).Click();

// Evidência do resultado.
capturaImagem();
```

Isso permite criar uma sequência de evidências:

```text
Imagem_1.png → Estado inicial
Imagem_2.png → Após preenchimento
Imagem_3.png → Após interação
Imagem_4.png → Resultado final
```

Esse recurso pode ser bastante útil para documentar a execução de cenários automatizados.

## ⚠️ Observação sobre Thread.Sleep()

O exemplo original utiliza:

```csharp
Thread.Sleep(500);
```

para aguardar a captura.

Embora seja suficiente para demonstrar o funcionamento, `Thread.Sleep()` não é normalmente a melhor estratégia de sincronização em uma suíte de testes.

Em automações reais, é preferível utilizar mecanismos de espera baseados em condições, como **explicit waits**, quando houver algum comportamento específico da aplicação que precise ser aguardado.

Além disso, a captura do screenshot em si é uma operação síncrona: não é necessário utilizar `Thread.Sleep()` para que o Selenium "termine" de salvar a imagem.

## 💡 Melhorias possíveis

A implementação pode ser evoluída para:

* Criar automaticamente a pasta de evidências;
* Utilizar data e hora no nome do arquivo;
* Associar o screenshot ao nome do cenário;
* Capturar automaticamente screenshots quando um teste falhar;
* Criar subpastas por execução;
* Armazenar evidências em uma estrutura organizada por suíte ou cenário.

Por exemplo, uma estrutura de evidências poderia ser:

```text
Evidencias/
│
├── Login/
│   ├── Login_01.png
│   └── Login_02.png
│
├── Cadastro/
│   ├── Cadastro_01.png
│   └── Cadastro_02.png
│
└── Pesquisa/
    ├── Pesquisa_01.png
    └── Pesquisa_02.png
```

## 🎯 Quando utilizar screenshots

A captura de screenshots pode ser útil para:

* Evidências de execução;
* Investigação de falhas;
* Depuração de testes;
* Documentação de cenários;
* Demonstrações de automação;
* Análise visual do estado da aplicação;
* Registro do resultado de etapas específicas do teste.

Em uma suíte de testes automatizados, uma estratégia bastante comum é capturar screenshots **automaticamente quando um teste falha**, evitando gerar evidências desnecessárias para todos os passos de todos os cenários.

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

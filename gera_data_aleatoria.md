# Gerador de data aleatória

Este exemplo demonstra como criar um método para **gerar datas aleatórias válidas** para utilização em testes automatizados com Selenium WebDriver.

A cada execução do método `GerarData()`, uma nova data é criada dentro do intervalo definido no código.

Esse tipo de recurso é útil para gerar **dados de teste dinamicamente**, evitando a necessidade de utilizar sempre os mesmos valores.

---

## 📋 Pré-requisitos

O exemplo original foi desenvolvido utilizando **Visual Studio, NUnit e Selenium WebDriver**.

As dependências utilizadas na época incluíam:

```text id="n3wq6k"
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
```

Para executar o exemplo no Chrome, também era necessário:

```text id="x8e4al"
Selenium.WebDriver.ChromeDriver
```

Para outros navegadores, poderiam ser utilizados os respectivos drivers:

```text id="gq7h2s"
Selenium.WebDriver.IEDriver
Selenium.WebDriver.Firefox
```

> **⚠️ Observação:** essas dependências refletem o ambiente original do exemplo. Em versões atuais do .NET, NUnit, Selenium e Visual Studio, a instalação e o gerenciamento dos pacotes podem ser diferentes.

---

# 📅 Criando o gerador de data

Depois de criar um **Unit Test Project**, o método `GerarData()` pode ser declarado dentro da classe marcada com `[TestFixture]`.

O método utiliza a classe `Random` para definir aleatoriamente:

* ano;
* mês;
* dia.

```csharp id="h1q5b9"
public DateTime GerarData()
{
    Random rnd = new Random();

    int ano = rnd.Next(1950, 2016);
    int mes = rnd.Next(1, 13);

    int ultimoDia =
        DateTime.DaysInMonth(ano, mes);

    int dia =
        rnd.Next(1, ultimoDia + 1);

    return new DateTime(ano, mes, dia);
}
```

O método retorna um objeto `DateTime`.

Por exemplo:

```text id="v8r2kc"
15/07/1998
```

---

## 🔎 Como o método funciona?

### 1. Geração do ano

O intervalo de anos é definido através de:

```csharp id="x8a5nc"
int ano = rnd.Next(1950, 2016);
```

Nesse caso, são gerados anos de **1950 até 2015**.

Isso acontece porque o limite superior do `Random.Next()` é exclusivo.

Caso seja necessário incluir o ano de 2016:

```csharp id="6d5h9q"
int ano = rnd.Next(1950, 2017);
```

---

### 2. Geração do mês

O mês é gerado entre 1 e 12:

```csharp id="1k5s3f"
int mes = rnd.Next(1, 13);
```

O `13` é utilizado porque o limite superior do `Random.Next()` não é incluído.

Assim, os valores possíveis são:

```text id="l0zq8s"
1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
```

---

### 3. Identificação do último dia do mês

Para evitar a geração de datas inválidas, o método utiliza:

```csharp id="8l4m5k"
int ultimoDia =
    DateTime.DaysInMonth(ano, mes);
```

Esse método retorna a quantidade correta de dias para o mês informado.

Por exemplo:

```text id="h1e6t0"
Fevereiro → 28 ou 29
Abril     → 30
Maio      → 31
```

Isso também considera automaticamente anos bissextos.

---

### 4. Geração do dia

Depois de descobrir quantos dias existem naquele mês:

```csharp id="2z6f9p"
int dia =
    rnd.Next(1, ultimoDia + 1);
```

Dessa forma, o dia sempre estará dentro de um intervalo válido.

Por exemplo, para um mês com 31 dias:

```text id="j9h0r2"
1 até 31
```

Para um mês com 30 dias:

```text id="p3w8xm"
1 até 30
```

---

### 5. Criação da data

Finalmente, os valores são utilizados para criar um `DateTime`:

```csharp id="w7k2ld"
return new DateTime(ano, mes, dia);
```

O resultado é uma data válida.

---

# 🧪 Veja o método funcionando

No exemplo abaixo, a data gerada é exibida em um `alert` utilizando o `IJavaScriptExecutor`.

```csharp id="r5x3qn"
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
        private IJavaScriptExecutor js;

        // Método para gerar uma data válida de forma aleatória
        public DateTime GerarData()
        {
            Random rnd = new Random();

            int ano = rnd.Next(1950, 2017);
            int mes = rnd.Next(1, 13);

            int ultimoDia =
                DateTime.DaysInMonth(ano, mes);

            int dia =
                rnd.Next(1, ultimoDia + 1);

            return new DateTime(ano, mes, dia);
        }

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
                // Ignora erros ao fechar o navegador.
            }
        }

        [Test]
        public void GeraData()
        {
            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("https://www.google.com.br");

            Thread.Sleep(2000);

            DateTime dataGerada = GerarData();

            js.ExecuteScript(
                "alert('Data gerada: " +
                dataGerada.ToString("dd/MM/yyyy") +
                "');"
            );

            Thread.Sleep(3000);
        }
    }
}
```

---

## ▶️ O que acontece durante a execução?

O fluxo do teste é:

```text id="c5h2nm"
Início
  │
  ├── Abre o Chrome
  │
  ├── Acessa a página definida no teste
  │
  ├── Executa GerarData()
  │       │
  │       ├── Gera um ano
  │       ├── Gera um mês
  │       ├── Identifica o último dia do mês
  │       └── Gera um dia válido
  │
  ├── Retorna um DateTime
  │
  └── Exibe a data em um alert
```

O navegador exibirá uma mensagem semelhante a:

```text id="r0c7yv"
Data gerada: 15/07/1998
```

Na próxima execução, outra data poderá ser gerada.

---

# 🔄 Utilizando a data em um campo

Como `GerarData()` retorna um `DateTime`, quando a data precisar ser enviada para um campo do navegador, é necessário convertê-la para uma representação textual.

Por exemplo:

```csharp id="n2j5cv"
string data = GerarData().ToString("dd/MM/yyyy");

driver.FindElement(By.Id("MainContent_txtDataNascimento"))
    .SendKeys(data);
```

Também é possível armazenar o valor em uma variável antes de utilizá-lo:

```csharp id="v6p9kr"
DateTime dataGerada = GerarData();

driver.FindElement(By.Id("MainContent_txtDataNascimento"))
    .SendKeys(dataGerada.ToString("dd/MM/yyyy"));
```

### 💡 Por que utilizar `ToString("dd/MM/yyyy")`?

O formato explícito evita depender da configuração regional do computador.

Em vez de:

```csharp id="m8x4qs"
Convert.ToString(GerarData())
```

é preferível definir explicitamente o formato esperado pelo campo:

```csharp id="b2n7wd"
GerarData().ToString("dd/MM/yyyy")
```

Isso é especialmente importante quando o sistema espera uma data no formato brasileiro.

---

# 📌 Exemplo aplicado a um cadastro

Supondo que o sistema possua um campo de data de nascimento:

```csharp id="u4k6pw"
DateTime dataNascimento = GerarData();

driver.FindElement(
    By.Id("MainContent_txtDataNascimento")
)
.SendKeys(
    dataNascimento.ToString("dd/MM/yyyy")
);
```

Nesse caso, o teste gera a data e imediatamente a utiliza no formulário.

---

## ⚠️ Atenção ao código original

O exemplo original utilizava:

```csharp id="j7d3sx"
int mes = rnd.Next(1, 12);
```

Como o segundo parâmetro de `Random.Next()` é exclusivo, esse código gera apenas os meses de **1 a 11**.

Para incluir dezembro, o correto é:

```csharp id="q5v9lm"
int mes = rnd.Next(1, 13);
```

O mesmo cuidado é necessário para o dia.

O código original utilizava:

```csharp id="e6c1hp"
int Dia = rnd.Next(1, dia);
```

Como o limite superior também é exclusivo, o último dia do mês nunca seria escolhido.

Por isso, utilizamos:

```csharp id="t9k2wf"
int dia = rnd.Next(1, ultimoDia + 1);
```

Assim, todos os dias válidos do mês podem ser selecionados.

---

## 💡 Por que gerar datas aleatórias?

A geração dinâmica de datas pode ser útil para testes que precisam:

* preencher campos de data;
* testar cadastros;
* gerar datas de nascimento;
* testar diferentes valores;
* evitar dados fixos;
* criar massas de teste dinamicamente;
* validar regras relacionadas a datas.

Por exemplo, em um cadastro:

```text id="k4z8pd"
Nome:             João da Silva
CPF:              12345678909
Data nascimento:  15/07/1998
```

A data pode ser gerada automaticamente pelo teste em vez de permanecer fixa.

---

## 🎯 Quando utilizar?

Um gerador de datas é especialmente útil quando o teste precisa trabalhar com **dados variáveis**.

Dependendo da regra do sistema, o intervalo pode ser adaptado.

Por exemplo, para gerar apenas datas recentes:

```csharp id="x5m9rb"
int ano = rnd.Next(2020, 2027);
```

Ou, para gerar datas anteriores a uma determinada data, pode-se trabalhar diretamente com objetos `DateTime` e intervalos de datas.

O importante é que o gerador seja ajustado à **regra de negócio que o teste pretende validar**.

---

## 🚀 Evolução do exemplo

Em um projeto maior, o método `GerarData()` pode ser movido para uma **classe externa de utilidades**, assim como o gerador de CPF.

Por exemplo:

```text id="z2r6vc"
Utils
├── GeraCPF.cs
└── GeraData.cs
```

A classe de teste passa então a consumir o método:

```csharp id="n8w3lk"
GeraData gerador = new GeraData();

DateTime data = gerador.GerarData();
```

Essa abordagem evita duplicar o mesmo código em vários testes e facilita a manutenção dos geradores de dados.

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

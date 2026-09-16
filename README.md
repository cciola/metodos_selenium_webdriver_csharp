# Métodos - Selenium WebDriver com C#

Este repositório reúne exemplos de funcionalidades comumente utilizadas em **Selenium WebDriver**, desenvolvidos na linguagem **C#**.

Os exemplos têm como objetivo servir como material de consulta e estudo para quem está iniciando na utilização do Selenium WebDriver para automação de testes.

---

## 📚 Sobre o Selenium WebDriver

O **Selenium WebDriver** é uma ferramenta utilizada para automação de navegadores, permitindo controlar o browser diretamente por meio de recursos e APIs disponibilizados pelo próprio navegador.

Com o WebDriver, é possível automatizar diversas ações realizadas por um usuário, como:

* Preenchimento de formulários;
* Digitação em campos de texto;
* Seleção de opções em menus dropdown;
* Interação com elementos da página;
* Submissão de formulários;
* Leitura e validação de informações presentes nos elementos HTML;
* Execução de comandos diretamente no navegador.

O WebDriver possui implementações específicas para diferentes navegadores, permitindo que os testes sejam executados em ambientes como **Chrome, Firefox, Internet Explorer e Opera**.

Essa integração direta com o navegador possibilita a criação de testes mais completos e reduz algumas das limitações existentes quando a automação é realizada exclusivamente por JavaScript dentro da aplicação.

---

## 🟨 Sobre o JavascriptExecutor

Além dos recursos disponibilizados pelo próprio Selenium WebDriver, também é possível executar comandos JavaScript diretamente no navegador utilizando o **JavascriptExecutor**.

Ele utiliza a interface `IJavaScriptExecutor`, que permite executar comandos JavaScript diretamente no navegador controlado pelo WebDriver.

O JavascriptExecutor permite, por exemplo:

* Executar comandos JavaScript;
* Realizar scroll na página;
* Simular eventos como `mouseover`;
* Exibir mensagens ou popups;
* Destacar elementos durante a execução dos testes;
* Executar scripts específicos para apoiar a automação.

Nos exemplos deste repositório, o JavascriptExecutor é utilizado para demonstrar algumas dessas possibilidades.

### Conversão
Antes de utilizá-lo, declare o objeto na classe de teste:

```csharp
[TestFixture]
public class NomeDoProjeto
{
    public IWebDriver driver;

    IJavaScriptExecutor js;
}
```

Depois, faça a conversão do `driver`:

```csharp
`js = (IJavaScriptExecutor)driver;`
```

A partir desse momento, o objeto `js` poderá ser utilizado para executar comandos JavaScript no navegador.

---

## ⚙️ Pré-requisitos

Todos os exemplos foram originalmente desenvolvidos e executados em um ambiente  utilizando **Microsoft Visual Studio / TFS, C#, NUnit e Selenium WebDriver**.

Para executar os exemplos nos navegadores, era necessário:

```text
Selenium.WebDriver.ChromeDriver // Chrome
Selenium.WebDriver.IEDriver     // Internet Explorer
Selenium.WebDriver.Firefox      // Mozilla Firefox
```

Dependências utilizadas na época incluíam:

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
```

> **⚠️ Observação:** essas dependências refletem o ambiente original do exemplo. Em versões atuais do .NET, NUnit, Selenium e Visual Studio, a instalação e o gerenciamento dos pacotes podem ser diferentes. Algumas versões e configurações dos navegadores também podem exigir adaptações para ambientes atuais.

---

## 📂 Exemplos disponíveis

Até o momento, o repositório contém os seguintes exemplos:

### Captura de screenshot

**[captura_screenshot](captura_screenshot.md)**

Exemplo de implementação de captura de screenshot durante a execução da automação.

O exemplo demonstra como:

* Capturar a tela;
* Salvar a imagem em um diretório definido;
* Utilizar um nome personalizado;
* Gerar numeração automática;
* Evitar que novas imagens sobrescrevam screenshots anteriores.

---

### Geração de CPF aleatório

**[gera_cpf_aleatorio](gera_cpf_aleatorio.md)**

Exemplo de implementação para geração randômica de **CPF válido**, útil para cenários de teste que necessitam de dados dinâmicos.

---

### Geração de data aleatória

**[gera_data_aleatoria](gera_data_aleatoria.md)**

Exemplo de implementação para geração randômica de **datas válidas**, permitindo criar dados variados durante a execução dos testes.

---

### JavascriptExecutor — Mouseover

**[jse_mouseover](jse_mouseover.md)**

Exemplo de utilização do **JavascriptExecutor** para executar o comando `mouseover` sobre um elemento da página.

---

### JavascriptExecutor — Scroll

**[jse_scroll_barra_rolagem](jse_scroll_barra_rolagem.md)**

Exemplo de utilização do **JavascriptExecutor** para realizar o **scroll** da página durante a execução da automação.

---

### JavascriptExecutor — Popup

**[jse_exibir_popup](jse_exibir_popup.md)**

Exemplo de utilização do **JavascriptExecutor** para executar JavaScript e exibir um **popup** na página.

---

### JavascriptExecutor — Destaque de elemento

**[jse_destaque_elemento](jse_destaque_elemento.md)**

Exemplo de utilização do **JavascriptExecutor** para destacar visualmente um elemento da página durante a execução do teste.

Esse recurso pode ser útil principalmente durante a execução em modo visual, facilitando a identificação do elemento que está sendo manipulado pela automação.

---

## 🎯 Objetivo do repositório

Este repositório foi criado inicialmente como um espaço de **estudo e compartilhamento de exemplos práticos** relacionados ao Selenium WebDriver com C#.

Os exemplos representam funcionalidades que podem ser reutilizadas ou adaptadas em projetos de automação de testes.

> ℹ O conteúdo deste repositório pode ser atualizado conforme novos exemplos e funcionalidades forem incorporados.

# Métodos - Selenium WebDriver com C#

Este repositório reúne exemplos de funcionalidades comumente utilizadas em **Selenium WebDriver**, desenvolvidos na linguagem **C#**. Os exemplos têm como objetivo servir como material de consulta e estudo para quem está iniciando na utilização do Selenium WebDriver para automação de testes.

---

## 📚 Sobre o Selenium WebDriver

O **Selenium WebDriver** é uma ferramenta utilizada para automação de navegadores, permitindo controlar o browser diretamente por meio de recursos e APIs disponibilizados pelo próprio navegador. O WebDriver possui implementações específicas para diferentes navegadores, permitindo que os testes sejam executados em ambientes como **Chrome, Firefox, Internet Explorer e Opera**. Essa integração direta com o navegador possibilita a criação de testes mais completos e reduz algumas das limitações existentes quando a automação é realizada exclusivamente por JavaScript dentro da aplicação.

---

## 🟨 Sobre o JavascriptExecutor

Além dos recursos disponibilizados pelo próprio Selenium WebDriver, também é possível executar comandos JavaScript diretamente no navegador utilizando o **JavascriptExecutor**. Ele utiliza a interface `IJavaScriptExecutor`, que permite executar comandos JavaScript diretamente no navegador controlado pelo WebDriver. Nos exemplos deste repositório, o JavascriptExecutor é utilizado para demonstrar algumas dessas possibilidades.

## ⚙️ Pré-requisitos

Todos os exemplos foram originalmente desenvolvidos e executados em um ambiente  utilizando **Microsoft Visual Studio TFS, C#, NUnit e Selenium WebDriver**.

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

## 🧪 Exemplos disponíveis

* **[Captura de screenshots](captura_screenshot.md)**
* **[Geração de CPF aleatório](gera_cpf_aleatorio.md)**
* **[Geração de data aleatória](gera_data_aleatoria.md)**
* **[Verificador de exportação de arquivo](verifica_arq_exportado.md)**
* **[JavascriptExecutor - mouseover](jse_mouseover.md)**
* **[JavascriptExecutor - scroll/barra de rolagem](jse_scroll_barra_rolagem.md)**
* **[JavascriptExecutor - exibição de pop-up](jse_exibir_popup.md)**
* **[JavascriptExecutor - destaque de elemento](jse_destaque_elemento.md)**

## 🎯 Observações
Este repositório foi criado inicialmente como um espaço de estudo e compartilhamento de exemplos práticos durante o aprendizado do Selenium WebDriver com C#. Os exemplos aqui apresentados representam funcionalidades que foram exploradas e utilizadas em automações, podendo ser reutilizados e adaptados conforme a necessidade de cada projeto.

## 🤝 Contribuições
Sugestões, melhorias e novos exemplos são bem-vindos! Caso você tenha alguma dúvida, sugestão ou queira contribuir com o projeto, fique à vontade para entrar em contato.

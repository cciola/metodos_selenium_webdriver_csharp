# Selenium WebDriver com C#

Este repositório reúne exemplos de funcionalidades comumente utilizadas em **Selenium WebDriver**, desenvolvidos na linguagem **C#**.

Os exemplos têm como objetivo servir como material de consulta e estudo para quem está iniciando na utilização do Selenium WebDriver para automação de testes.

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

## 🟨 JavascriptExecutor

Além dos recursos disponibilizados pelo próprio Selenium WebDriver, também é possível executar comandos JavaScript diretamente no navegador utilizando o **JavascriptExecutor**.

O JavascriptExecutor permite, por exemplo:

* Executar comandos JavaScript;
* Realizar scroll na página;
* Simular eventos como `mouseover`;
* Exibir mensagens ou popups;
* Destacar elementos durante a execução dos testes;
* Executar scripts específicos para apoiar a automação.

Nos exemplos deste repositório, o JavascriptExecutor é utilizado para demonstrar algumas dessas possibilidades.

## ⚙️ Pré-requisitos

Os exemplos foram originalmente elaborados e executados em um ambiente contendo:

* **Selenium WebDriver**
* **C#**
* **Microsoft Visual Studio / TFS**
* Um navegador compatível, como:

  * Google Chrome
  * Mozilla Firefox
  * Internet Explorer

> **Observação:** os exemplos foram desenvolvidos originalmente em um ambiente que utilizava Internet Explorer, Chrome e Firefox. Algumas versões e configurações podem exigir adaptações para ambientes atuais.

## 📂 Exemplos disponíveis

Até o momento, o repositório contém os seguintes exemplos:

### 📸 Captura de screenshot

**[captura_screenshot](captura_screenshot.md)**

Exemplo de implementação de captura de screenshot durante a execução da automação.

O exemplo demonstra como:

* Capturar a tela;
* Salvar a imagem em um diretório definido;
* Utilizar um nome personalizado;
* Gerar numeração automática;
* Evitar que novas imagens sobrescrevam screenshots anteriores.

---

### 🆔 Geração de CPF aleatório

**[gera_CPF_aleatorio](gera_CPF_aleatorio.md)**

Exemplo de implementação para geração randômica de **CPF válido**, útil para cenários de teste que necessitam de dados dinâmicos.

---

### 📅 Geração de data aleatória

**[gera_data_aleatoria](gera_data_aleatoria.md)**

Exemplo de implementação para geração randômica de **datas válidas**, permitindo criar dados variados durante a execução dos testes.

---

### 🖱️ JavascriptExecutor — Mouseover

**[JavascriptExecutor_mouseover](JsE_mouseover.md)**

Exemplo de utilização do **JavascriptExecutor** para executar o comando `mouseover` sobre um elemento da página.

---

### 📜 JavascriptExecutor — Scroll

**[JavascriptExecutor_scroll](JsE_scroll.md)**

Exemplo de utilização do **JavascriptExecutor** para realizar o **scroll** da página durante a execução da automação.

---

### 💬 JavascriptExecutor — Popup

**[JavascriptExecutor_popup](JsE_popup.md)**

Exemplo de utilização do **JavascriptExecutor** para executar JavaScript e exibir um **popup** na página.

---

### ✨ JavascriptExecutor — Destaque de elemento

**[JavascriptExecutor_destaque](JsE_destaque.md)**

Exemplo de utilização do **JavascriptExecutor** para destacar visualmente um elemento da página durante a execução do teste.

Esse recurso pode ser útil principalmente durante a execução em modo visual, facilitando a identificação do elemento que está sendo manipulado pela automação.

## 🎯 Objetivo do repositório

Este repositório foi criado inicialmente como um espaço de **estudo e compartilhamento de exemplos práticos** relacionados ao Selenium WebDriver com C#.

Os exemplos representam funcionalidades que podem ser reutilizadas ou adaptadas em projetos de automação de testes.

> O conteúdo deste repositório pode ser atualizado conforme novos exemplos e funcionalidades forem incorporados.

## 👩‍💻 Sobre

Repositório criado por **Carol Ciola**, como material de estudo e referência sobre automação de testes com Selenium WebDriver e C#.

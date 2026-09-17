# Captura de screenshot

Este exemplo demonstra como utilizar o **Selenium WebDriver** para capturar screenshots durante a execução de testes automatizados. Esse recurso pode ser especialmente útil para **evidências de testes**, **depuração** e investigação de falhas durante a execução da automação. Em uma suíte de testes automatizados, uma estratégia bastante comum é capturar screenshots **automaticamente quando um teste falha**, evitando gerar evidências desnecessárias para todos os passos de todos os cenários.

## Explicação detalhada

O Selenium disponibiliza a interface `ITakesScreenshot`, que permite solicitar ao navegador uma captura da tela atual. Primeiro, declare as variáveis necessárias na classe de teste:

```csharp
[TestFixture]
public class NomeDoProjeto
{
    // Representa o navegador controlado pelo Selenium
    public IWebDriver driver;

    // Armazena a URL base da aplicação
    private string baseURL;

    // Armazena o diretório onde os screenshots serão salvos
    public string screenshotsPasta;

    // Controla a numeração dos arquivos gerados
    int contador = 1;
}
```

Criando o método de captura:

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

Em `ITakesScreenshot`, o `driver` é convertido para `ITakesScreenshot`, permitindo utilizar os recursos de captura de tela disponibilizados pelo Selenium. A instrução `Screenshot foto = camera.GetScreenshot();` solicita ao WebDriver uma captura da tela atual e armazena o resultado na variável `foto`. O método `SaveAsFile` salva a captura no caminho informado. O segundo parâmetro `ScreenshotImageFormat.Png` define o formato da imagem. Neste exemplo, os arquivos serão salvos no formato `.png`.

O diretório onde os screenshots serão armazenados pode ser configurado no método `[SetUp]`:

```csharp
[SetUp]
public void SetupTest()
{
    // Inicializa o navegador Chrome
    driver = new ChromeDriver();

    // Maximiza a janela do navegador
    driver.Manage().Window.Maximize();

    // Define a URL base utilizada pelo teste
    baseURL = "https://www.google.com.br";

    // Define o diretório onde os screenshots
    screenshotsPasta = @"C:\Users\cciola\Documents\Evidencias\";
}
```

> **💡 Importante:** a pasta informada deve existir **antes** da execução do teste. Em uma implementação mais robusta, o código pode verificar a existência do diretório e criá-lo automaticamente quando necessário.

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

O trecho `"Imagem_" + contador++ + ".png"` gera nomes sequenciais, por exemplo:

```text
Imagem_1.png
Imagem_2.png
Imagem_3.png
Imagem_4.png
```

O operador `++` incrementa o valor do contador após sua utilização. Assim, cada nova chamada do método `capturaImagem()` gera um nome diferente.

Depois que os métodos forem implementados, basta chamar `capturaImagem();` no ponto em que deseja obter a evidência, por exemplo:

```csharp
driver.Navigate().GoToUrl(
    baseURL + "/intl/pt-BR/about/"
);

Thread.Sleep(1000);
capturaImagem();
```

Nesse caso, o screenshot será capturado após o carregamento da página.

---

## Veja o método funcionando

📜 **[captura_screenshot.cs](./scripts/captura_screenshot.cs)**

Durante a execução, o teste:

1. Inicializa o Chrome;
2. Maximiza a janela;
3. Acessa a URL configurada;
4. Aguarda o carregamento da página;
5. Captura um screenshot;
6. Salva a imagem na pasta configurada.

Exemplo:

```text
C:\Selenium\Evidencias\
│
├── Imagem_1.png
├── Imagem_2.png
├── Imagem_3.png
└── Imagem_4.png
```

Cada chamada ao método `capturaImagem()` gera uma nova imagem numerada.

Uma das vantagens dessa abordagem é poder realizar screenshots em diferentes momentos do teste. Por exemplo:

```csharp
// Evidência após abrir a página
capturaImagem();

// Executa uma ação
driver.FindElement(By.Id("campo")).Click();

// Evidência após a ação
capturaImagem();

// Executa outra ação
driver.FindElement(By.Id("botao")).Click();

// Evidência do resultado
capturaImagem();
```

Isso permite criar uma sequência de evidências:

```text
Imagem_1.png → Estado inicial
Imagem_2.png → Após preenchimento
Imagem_3.png → Após interação
Imagem_4.png → Resultado final
```

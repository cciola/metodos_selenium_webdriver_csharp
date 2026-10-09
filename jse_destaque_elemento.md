# Exibir destaque de elemento com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para destacar visualmente um elemento da página durante a execução de um teste automatizado. O destaque pode ser útil principalmente durante a execução dos testes em modo visual, facilitando a identificação do elemento que está sendo manipulado pela automação.

## Explicação detalhada

Declare o objeto `IJavaScriptExecutor` na classe de teste:

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

Depois que o método `destaque()` estiver implementado, basta localizar o elemento desejado e enviá-lo como parâmetro:

```csharp
destaque(
    driver.FindElement(
        By.Id("informe-o-ID-do-elemento")
    )
);
```

Nesse caso, o Selenium localiza o elemento pelo seu `id` e o método `destaque()` aplica o estilo definido.

### Veja o método funcionando

📜 **[jse_destaque_elemento.cs](./scripts/jse_destaque_elemento.cs)**

Durante a execução, o teste:

1. Abre o Google Chrome;
2. Maximiza a janela;
3. Acessa o Google;
4. Localiza o campo de pesquisa;
5. Destaca o campo;
6. Digita o texto `teste de software`;
7. Pressiona `Enter`;
8. Realiza a pesquisa.

O campo de pesquisa localizado pelo Selenium recebe o seguinte estilo:

```css
color: yellow;
border: 4px solid yellow;
```

Visualmente, o elemento fica destacado na página, permitindo acompanhar com mais facilidade qual elemento está sendo manipulado pelo teste.

> 💡 **Atenção:** o exemplo acima foi desenvolvido originalmente utilizando os elementos e IDs disponíveis no Google na época em que o código foi criado. Como a estrutura HTML de sites pode mudar, os IDs `sb_ifc0` e `lst-ib` podem não estar disponíveis atualmente. Nesse caso, substitua-os pelo identificador correspondente ao elemento existente na página.

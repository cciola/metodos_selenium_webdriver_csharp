# Executar scroll da barra de rolagem com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para controlar a barra de rolagem de uma página por meio de JavaScript. A técnica permite movimentar a página vertical ou horizontalmente durante a execução de um teste automatizado.

> 💡 É interessante avaliar se o próprio Selenium já oferece uma forma adequada de realizar a interação necessária.

---

## Explicação detalhada

Para movimentar a página, podemos utilizar o método JavaScript `window.scrollBy(x, y)`. Os parâmetros representam o deslocamento em pixels:

* `x` - deslocamento horizontal;
* `y` - deslocamento vertical.

Por exemplo, `window.scrollBy(0, 300)` significa: **não** movimentar horizontalmente (`0`), e descer **300 pixels** verticalmente (`300`).

No Selenium, podemos executar o JavaScript para deslocar a página **300 pixels para baixo**:

```csharp
js.ExecuteScript(
    "window.scrollBy(0, 300);"
);
```

Para retornar 300 pixels, como o valor vertical é **negativo**, a página será deslocada **300 pixels para cima**:

```csharp
js.ExecuteScript(
    "window.scrollBy(0, -300);"
);
```

## Veja o método funcionando

📜 **[jse_scroll_barra_rolagem.cs](./scripts/jse_scroll_barra_rolagem.cs)**

Durante a execução, o teste:

1. Acessa a página configurada em `baseURL`;
2. Executa o evento `window.scrollBy()` para baixo (página deslocada);
3. Executa o evento `window.scrollBy()` para cima (retorna à posição anterior).

Assim, será possível visualizar a página sendo movimentada para baixo e, posteriormente, retornando para cima.

## Outras formas de utilizar o scroll

Rolar até o final da página:

```csharp
js.ExecuteScript(
    "window.scrollTo(0, document.body.scrollHeight);"
);
```

Rolar até o início da página:

```csharp
js.ExecuteScript(
    "window.scrollTo(0, 0);"
);
```

Rolar até um elemento específico:

```csharp
IWebElement elemento = driver.FindElement(
    By.Id("id-do-elemento")
);

js.ExecuteScript(
    "arguments[0].scrollIntoView();",
    elemento
);
```

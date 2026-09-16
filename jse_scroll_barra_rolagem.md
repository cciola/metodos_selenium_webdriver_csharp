# Executar scroll da barra de rolagem com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para controlar a barra de rolagem de uma página por meio de JavaScript.

A técnica permite movimentar a página vertical ou horizontalmente durante a execução de um teste automatizado.

Neste exemplo, a página é:

1. Acessada pelo Selenium WebDriver;
2. Rolada para baixo;
3. Rolada novamente para cima.

---

## Quando utilizar

O scroll pode ser útil para:

* Controlar a posição da página;
* Rolar páginas longas;
* Acessar elementos que estão fora da área visível;
* Rolar até um elemento específico;
* Auxiliar na automação de páginas com comportamentos específicos de JavaScript;
* Investigar problemas relacionados à posição dos elementos durante a execução dos testes.

Sempre que possível, porém, é interessante avaliar se o próprio Selenium já oferece uma forma adequada de realizar a interação necessária.

---

## Utilizando window.scrollBy()

Para movimentar a página, podemos utilizar o método JavaScript `window.scrollBy(x, y)`. Os parâmetros representam o deslocamento em pixels:

* `x` — deslocamento horizontal;
* `y` — deslocamento vertical.

Por exemplo, `window.scrollBy(0, 300)` significa:

* Não movimentar horizontalmente (`0`);
* Descer **300 pixels** verticalmente (`300`).

---

##  Rolando a página para baixo

No Selenium, podemos executar o JavaScript da seguinte forma:

```csharp
js.ExecuteScript(
    "window.scrollBy(0, 300);"
);
```

Nesse caso, a página será deslocada **300 pixels para baixo**.

---

## Rolando a página para cima

Para retornar 300 pixels:

```csharp
js.ExecuteScript(
    "window.scrollBy(0, -300);"
);
```

Como o valor vertical é negativo, a página será deslocada **300 pixels para cima**.

---

## Veja o método funcionando

**[jse_scroll_barra_rolagem.cs](./scripts/jse_scroll_barra_rolagem.cs)**

Durante a execução, o teste:

1. Acessa a página configurada em `baseURL`;
2. Executa o evento `window.scrollBy()` para baixo (página deslocada);
3. Executa o evento `window.scrollBy()` para cima (retorna à posição anterior).

Assim, será possível visualizar a página sendo movimentada para baixo e, posteriormente, retornando para cima.

---

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

---

## 🎯 Objetivo do repositório

Este exemplo faz parte da série de exemplos de **Selenium WebDriver com C#** deste repositório. Como o estudo da ferramenta é incremental, novos exemplos podem ser adicionados conforme novos recursos forem explorados. A ideia é manter os códigos como uma **referência rápida** para funcionalidades que podem ser reutilizadas em diferentes scripts de automação.

## 🤝 Contribuições

Sugestões, melhorias e novos exemplos são bem-vindos! Caso você tenha alguma dúvida, sugestão ou queira contribuir com o projeto, fique à vontade para entrar em contato.

## 📌 Observação

Este repositório foi criado inicialmente como material de estudo e referência pessoal durante o aprendizado do Selenium WebDriver com C#. Os exemplos aqui apresentados representam funcionalidades que foram exploradas e utilizadas em automações, podendo ser adaptados conforme a necessidade de cada projeto.

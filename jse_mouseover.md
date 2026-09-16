# Executar mouseover (hover) com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para executar a ação de **mouseover (hover)** sobre um elemento da página.

A técnica pode ser utilizada em situações nas quais um menu ou outro elemento da interface apresenta informações adicionais, como **submenus, opções ou menus dropdown**, quando o cursor do mouse é posicionado sobre ele.

---

## O que é mouseover (hover)?

O **mouseover**, também conhecido como **hover**, ocorre quando o cursor do mouse é posicionado sobre determinado elemento da página.

Um exemplo comum é um menu de navegação que exibe opções adicionais quando o usuário posiciona o mouse sobre ele:

```text
MENU PRINCIPAL
       ↓
┌─────────────────┐
│ Opção 1         │
│ Opção 2         │
│ Opção 3         │
└─────────────────┘
```

Durante uma automação, podemos precisar reproduzir esse comportamento para verificar se o submenu ou outra informação é exibida corretamente.

---

## Quando utilizar

Essa técnica pode ser útil para:

* Interagir com menus dropdown;
* Acionar eventos JavaScript específicos;
* Investigar comportamentos da interface;
* Auxiliar na depuração de testes;
* Automatizar aplicações legadas que dependem de eventos JavaScript.

Para aplicações modernas, recomenda-se avaliar primeiro se a interação pode ser realizada diretamente pelas APIs de interação do Selenium, utilizando `Actions` e outros recursos nativos do WebDriver.

---

## Utilizando JavascriptExecutor

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

Antes de executar o JavaScript, faça a conversão do `driver`: `js = (IJavaScriptExecutor)driver;`. Essa conversão permite utilizar o objeto `js` para executar scripts no navegador.

---

## Executando o mouseover

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

Após executar o evento, o teste pode aguardar alguns instantes para permitir a visualização do resultado: `Thread.Sleep(3000);`.

---

## Veja o método funcionando

**[jse_mouseover.cs](./scripts/jse_mouseover.cs)**

Durante a execução, o teste:

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

> **💡 Observação importante:** Este exemplo utiliza diretamente o evento JavaScript `arguments[0].onmouseover()`. Isso **não é exatamente a mesma coisa que mover fisicamente o cursor do mouse até o elemento**. O código dispara o evento `onmouseover` associado ao elemento.

Em aplicações modernas, o comportamento de menus pode ser implementado por outros mecanismos, como listeners JavaScript, CSS `:hover` ou frameworks de frontend. Nesses casos, a abordagem mais adequada pode ser utilizar os recursos de interação do próprio Selenium, como `Actions`, por exemplo:

```csharp
Actions actions = new Actions(driver);

actions.MoveToElement(menu).Perform();
```

Portanto, o JavascriptExecutor é uma alternativa útil quando é necessário executar diretamente um comportamento JavaScript específico.

---

## 🎯 Objetivo do repositório

Este exemplo faz parte da série de exemplos de **Selenium WebDriver com C#** deste repositório. Como o estudo da ferramenta é incremental, novos exemplos podem ser adicionados conforme novos recursos forem explorados. A ideia é manter os códigos como uma **referência rápida** para funcionalidades que podem ser reutilizadas em diferentes scripts de automação.

## 🤝 Contribuições

Sugestões, melhorias e novos exemplos são bem-vindos! Caso você tenha alguma dúvida, sugestão ou queira contribuir com o projeto, fique à vontade para entrar em contato.

### 📌 Observação

Este repositório foi criado inicialmente como material de estudo e referência pessoal durante o aprendizado do Selenium WebDriver com C#. Os exemplos aqui apresentados representam funcionalidades que foram exploradas e utilizadas em automações, podendo ser adaptados conforme a necessidade de cada projeto.

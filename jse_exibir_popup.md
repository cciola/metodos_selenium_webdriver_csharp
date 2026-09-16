# Exibir popup com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para executar JavaScript no navegador e exibir um **popup (`alert`)** durante a execução de um teste automatizado. O exemplo apresenta duas possibilidades:

### 1. Exibindo um popup com texto fixo

Para exibir um popup utilizando JavaScript, podemos utilizar a função `alert()`:

```csharp
js.ExecuteScript(
    "alert('Script de teste finalizado com sucesso!');"
);
```

**[jse_texto_fixo.cs](./scripts/jse_texto_fixo.cs)**

Durante a execução, o teste:

1. Inicializa o Chrome;
2. Cria uma instância do JavascriptExecutor;
3. Executa um `alert()` com um texto fixo;
4. Mantém o popup aberto por alguns segundos;
5. Encerra o navegador.

O navegador exibirá uma caixa de diálogo semelhante a:

```text
┌──────────────────────────────────────┐
│                                      │
│  Script de teste finalizado com      │
│  sucesso!                            │
│                                      │
│                              [ OK ]  │
└──────────────────────────────────────┘
```

---

### 2. Exibindo um popup com uma variável

Também é possível utilizar uma variável C# para montar o texto que será exibido no popup, exemplo: `public string variavel = "Carol";`.

O valor da variável pode ser concatenado ao JavaScript:

```csharp
js.ExecuteScript(
    "alert('Valor da variavel: " + variavel + "');"
);
```

**[jse_texto_e_variavel.cs](./scripts/jse_texto_e_variavel.cs)**

O navegador exibirá uma caixa de diálogo semelhante a:

```text
┌──────────────────────────────────────┐
│                                      │
│  Valor da variavel: Carol            │
│                                      │
│                              [ OK ]  │
└──────────────────────────────────────┘
```

---

### Exemplo utilizando um dado gerado pelo teste

O mesmo conceito pode ser utilizado para exibir informações geradas durante a execução do teste.

```csharp
js.ExecuteScript(
    "alert('CPF gerado: " + GerarCpf() + "');"
);
```

Nesse caso, o resultado da função `GerarCpf()` será concatenado à mensagem exibida no popup.

---

## Interagindo com o popup

O `alert()` utilizado neste exemplo é um **JavaScript Alert** do navegador.

Quando um alert está aberto, o navegador fica aguardando uma ação do usuário. Em uma automação real, normalmente será necessário tratá-lo utilizando os recursos de `IAlert` do Selenium.

Por exemplo, para aceitar o popup:

```csharp
IAlert alert = driver.SwitchTo().Alert();
alert.Accept();
```

Para obter o texto exibido:

```csharp
IAlert alert = driver.SwitchTo().Alert();
string mensagem = alert.Text;
```

Isso permite transformar o popup em parte de uma validação automatizada, em vez de apenas utilizá-lo para visualização.

---

## 🎯 Objetivo do repositório

Este exemplo faz parte da série de exemplos de **Selenium WebDriver com C#** deste repositório. Como o estudo da ferramenta é incremental, novos exemplos podem ser adicionados conforme novos recursos forem explorados. A ideia é manter os códigos como uma **referência rápida** para funcionalidades que podem ser reutilizadas em diferentes scripts de automação.

## 🤝 Contribuições

Sugestões, melhorias e novos exemplos são bem-vindos! Caso você tenha alguma dúvida, sugestão ou queira contribuir com o projeto, fique à vontade para entrar em contato.

## 📌 Observação

Este repositório foi criado inicialmente como material de estudo e referência pessoal durante o aprendizado do Selenium WebDriver com C#. Os exemplos aqui apresentados representam funcionalidades que foram exploradas e utilizadas em automações, podendo ser adaptados conforme a necessidade de cada projeto.

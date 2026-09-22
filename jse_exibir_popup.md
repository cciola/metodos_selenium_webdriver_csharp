# Exibir popup com JavascriptExecutor

Este exemplo demonstra como utilizar o **JavascriptExecutor** do Selenium WebDriver para executar JavaScript no navegador e exibir um **popup (`alert`)** durante a execução de um teste automatizado.

## Explicação detalhada

O exemplo apresenta duas possibilidades:

* Exibindo um popup com texto fixo
* Exibindo um popup com uma variável

## 1. Exibindo um popup com texto fixo

Para exibir um popup utilizando JavaScript, podemos utilizar a função `alert()`:

```csharp
js.ExecuteScript(
    "alert('Script de teste finalizado com sucesso!');"
);
```

📜 **[jse_texto_fixo.cs](./scripts/jse_texto_fixo.cs)**

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

## 2. Exibindo um popup com uma variável

Também é possível utilizar uma variável C# para montar o texto que será exibido no popup, exemplo: `public string variavel = "Carol";`. O valor da variável pode ser concatenado ao JavaScript:

```csharp
js.ExecuteScript(
    "alert('Valor da variavel: " + variavel + "');"
);
```

📜 **[jse_texto_e_variavel.cs](./scripts/jse_texto_e_variavel.cs)**

O navegador exibirá uma caixa de diálogo semelhante a:

```text
┌──────────────────────────────────────┐
│                                      │
│  Valor da variavel: Carol            │
│                                      │
│                              [ OK ]  │
└──────────────────────────────────────┘
```

### Exemplo utilizando um dado gerado pelo teste

O mesmo conceito pode ser utilizado para exibir informações geradas durante a execução do teste.

```csharp
js.ExecuteScript(
    "alert('CPF gerado: " + GerarCpf() + "');"
);
```

Nesse caso, o resultado da função `GerarCpf()` será concatenado à mensagem exibida no popup.

O `alert()` utilizado neste exemplo é um **JavaScript Alert** do navegador. Quando um alert está aberto, o navegador fica aguardando uma ação do usuário. Em uma automação real, normalmente será necessário tratá-lo utilizando os recursos de `IAlert` do Selenium. Por exemplo, para aceitar o popup:

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

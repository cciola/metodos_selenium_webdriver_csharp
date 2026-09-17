# Gerador de CPF aleatório

Este exemplo demonstra como criar um método para **gerar CPFs válidos de forma aleatória** e utilizá-los como dados de teste em uma automação com Selenium WebDriver. A cada execução do método `GerarCpf()`, um novo CPF é calculado a partir de uma sequência numérica aleatória e dos respectivos dígitos verificadores.

> **💡 Importante:** o objetivo deste gerador é criar **dados para testes**. Os CPFs gerados não devem ser utilizados para identificação de pessoas reais ou em situações fora do contexto de testes.

## Explicação detalhada

Depois de criar um **Unit Test Project**, o método `GerarCpf()` pode ser declarado dentro da classe marcada com `[TestFixture]`. O método retorna uma `string` contendo **11 dígitos**, correspondentes ao CPF sem máscara, por exemplo: `12345678909`.

📜 **[GeraCPF.cs](./scripts/GeraCPF.cs)**

O algoritmo pode ser dividido em algumas etapas:

**1. Geração da sequência inicial** - Primeiro é gerada aleatoriamente uma sequência de **9 dígitos**. Essa sequência é utilizada como base para o cálculo do CPF.

```csharp
Random rnd = new Random();

string semente =
    rnd.Next(100000000, 999999999).ToString();
```

**2. Cálculo do primeiro dígito verificador** - Os nove primeiros números são multiplicados pelos pesos `10  9  8  7  6  5  4  3  2`. A soma dos resultados é utilizada para calcular o primeiro dígito verificador.

**3. Cálculo do segundo dígito verificador** - Depois que o primeiro dígito é adicionado, o algoritmo utiliza os pesos `11  10  9  8  7  6  5  4  3  2`. Com isso, é calculado o segundo dígito verificador.

**4. Retorno do CPF** - Os dois dígitos calculados são adicionados à sequência inicial: **9 dígitos + 1º dígito verificador + 2º dígito verificador**. O resultado final possui 11 dígitos: `12345678909`.

## Veja o método funcionando

📜 **[gera_cpf_aleatorio.cs](./scripts/gera_cpf_aleatorio.cs)**

Durante a execução, o teste:

1. Inicializa o Chrome;
2. Acessa a URL configurada;
3. Executa GerarCpf();
4. Retorna o CPF gerado;
5. Exibe o CPF em um alert.

Exemplo de exibição do alert:

```text
CPF gerado: 12345678909
```

A cada nova execução, a sequência inicial é gerada aleatoriamente e, consequentemente, o CPF retornado tende a ser diferente.

A principal vantagem de possuir um método como `GerarCpf()` é poder utilizá-lo diretamente nos dados do teste. Por exemplo:

```csharp
string cpf = GerarCpf();

driver.FindElement(By.Id("campoCpf"))
    .SendKeys(cpf);
```

Também é possível utilizá-lo diretamente:

```csharp
driver.FindElement(By.Id("campoCpf"))
    .SendKeys(GerarCpf());
```

Isso permite evitar valores fixos nos testes:

```csharp
// Dado fixo
driver.FindElement(By.Id("campoCpf"))
    .SendKeys("12345678909");
```

E utilizar dados gerados dinamicamente:

```csharp
// Dado gerado dinamicamente
driver.FindElement(By.Id("campoCpf"))
    .SendKeys(GerarCpf());
```

## Observações

- **CPF válido não significa CPF existente.** O algoritmo verifica apenas a **estrutura matemática dos dígitos verificadores do CPF**. Portanto, um CPF gerado pelo método pode ser matematicamente válido, mas não necessariamente corresponde a uma pessoa ou cadastro real. Para testes de sistemas que consultam bases externas ou validam existência do CPF, devem ser utilizados dados apropriados ao ambiente de teste.

- O exemplo utiliza `Thread.Sleep()` para facilitar a visualização durante a demonstração. Em automações reais, o ideal é utilizar mecanismos de espera do Selenium, como **explicit waits**, quando for necessário aguardar uma condição específica da aplicação.

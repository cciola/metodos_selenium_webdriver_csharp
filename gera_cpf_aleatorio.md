# Gerador de CPF aleatório

Este exemplo demonstra como criar um método para **gerar CPFs válidos de forma aleatória** e utilizá-los como dados de teste em uma automação com Selenium WebDriver.

A cada execução do método `GerarCpf()`, um novo CPF é calculado a partir de uma sequência numérica aleatória e dos respectivos dígitos verificadores.

> **💡 Importante:** o objetivo deste gerador é criar **dados para testes**. Os CPFs gerados não devem ser utilizados para identificação de pessoas reais ou em situações fora do contexto de testes.

---

## Quando utilizar?

Um gerador de CPF é especialmente útil em testes que precisam:

* cadastrar novos usuários;
* preencher formulários;
* testar validações de CPF;
* evitar dados fixos;
* gerar diferentes massas de teste;
* validar fluxos de cadastro;
* testar cenários positivos e negativos relacionados ao CPF.

Para projetos maiores, o método `GerarCpf()` pode ser movido para uma **classe utilitária externa**, permitindo que vários testes reutilizem o mesmo gerador.

---

## Criando o gerador de CPF

Depois de criar um **Unit Test Project**, o método `GerarCpf()` pode ser declarado dentro da classe marcada com `[TestFixture]`.

O método retorna uma `string` contendo **11 dígitos**, correspondentes ao CPF sem máscara, por exemplo: `12345678909`.

**[GeraCPF.cs](./scripts/GeraCPF.cs)**

---

O algoritmo pode ser dividido em algumas etapas:

### 1. Geração da sequência inicial

Primeiro é gerada aleatoriamente uma sequência de **9 dígitos**. Essa sequência é utilizada como base para o cálculo do CPF.

```csharp
Random rnd = new Random();

string semente =
    rnd.Next(100000000, 999999999).ToString();
```

---

### 2. Cálculo do primeiro dígito verificador

Os nove primeiros números são multiplicados pelos pesos:

```text
10  9  8  7  6  5  4  3  2
```

A soma dos resultados é utilizada para calcular o primeiro dígito verificador.

---

### 3. Cálculo do segundo dígito verificador

Depois que o primeiro dígito é adicionado, o algoritmo utiliza os pesos:

```text
11  10  9  8  7  6  5  4  3  2
```

Com isso, é calculado o segundo dígito verificador.

---

### 4. Retorno do CPF

Os dois dígitos calculados são adicionados à sequência inicial:

```text
9 dígitos + 1º dígito verificador + 2º dígito verificador
```

O resultado final possui 11 dígitos:

```text
12345678909
```

---

## Veja o método funcionando

**[gera_cpf_aleatorio.cs](./scripts/gera_cpf_aleatorio.cs)**

Durante a execução, o teste:

1. Inicializa o Chrome;
2. Acessa a URL configurada;
3. Executa GerarCpf();
4. Retorna o CPF gerado;
5. Exibe o CPF em um alert.

Exemplo:

```text
CPF gerado: 12345678909
```

A cada nova execução, a sequência inicial é gerada aleatoriamente e, consequentemente, o CPF retornado tende a ser diferente.

---

## Utilizando o CPF em outros testes

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

---

## Por que gerar dados aleatórios?

Geradores de dados são úteis em automação porque permitem criar dados diferentes durante as execuções.

Alguns exemplos:

* CPF;
* datas;
* nomes;
* e-mails;
* telefones;
* endereços;
* números de documentos;
* outros dados necessários para os cenários de teste.

Isso reduz a dependência de dados fixos e pode facilitar a execução de cenários que exigem valores únicos.

---

**Observações:**

- **CPF válido não significa CPF existente.** O algoritmo verifica apenas a **estrutura matemática dos dígitos verificadores do CPF**. Portanto, um CPF gerado pelo método pode ser matematicamente válido, mas não necessariamente corresponde a uma pessoa ou cadastro real. Para testes de sistemas que consultam bases externas ou validam existência do CPF, devem ser utilizados dados apropriados ao ambiente de teste.

- O exemplo utiliza `Thread.Sleep()` para facilitar a visualização durante a demonstração. Em automações reais, o ideal é utilizar mecanismos de espera do Selenium, como **explicit waits**, quando for necessário aguardar uma condição específica da aplicação.

---

## 🎯 Objetivo do repositório

Este exemplo faz parte da série de exemplos de **Selenium WebDriver com C#** deste repositório.

Como o estudo da ferramenta é incremental, novos exemplos podem ser adicionados conforme novos recursos forem explorados.

A ideia é manter os códigos como uma **referência rápida** para funcionalidades que podem ser reutilizadas em diferentes scripts de automação.

## 🤝 Contribuições

Sugestões, melhorias e novos exemplos são bem-vindos! Caso você tenha alguma dúvida, sugestão ou queira contribuir com o projeto, fique à vontade para entrar em contato.

## 📌 Observação

Este repositório foi criado inicialmente como material de estudo e referência pessoal durante o aprendizado do Selenium WebDriver com C#. Os exemplos aqui apresentados representam funcionalidades que foram exploradas e utilizadas em automações, podendo ser adaptados conforme a necessidade de cada projeto.

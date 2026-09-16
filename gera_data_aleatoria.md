# Gerador de data aleatória

Este exemplo demonstra como criar um método para **gerar datas aleatórias válidas** para utilização em testes automatizados com Selenium WebDriver.

A cada execução do método `GerarData()`, uma nova data é criada dentro do intervalo definido no código.

Esse tipo de recurso é útil para gerar **dados de teste dinamicamente**, evitando a necessidade de utilizar sempre os mesmos valores.

---

## Quando utilizar?

Um gerador de datas é especialmente útil quando o teste precisa trabalhar com **dados variáveis**.

Dependendo da regra do sistema, o intervalo pode ser adaptado.

Por exemplo, para gerar apenas datas recentes: `int ano = rnd.Next(2020, 2027);`.


Ou, para gerar datas anteriores a uma determinada data, pode-se trabalhar diretamente com objetos `DateTime` e intervalos de datas.

O importante é que o gerador seja ajustado à **regra de negócio que o teste pretende validar**.

---

## Criando o gerador de data

**[GerarData.cs](./scripts/GerarData.cs)**

O método utiliza a classe `Random` para definir aleatoriamente **ano**, **mês** e **dia**.

O método retorna um objeto `DateTime`: `15/07/1998`.

---

## Como o método funciona?

### 1. Geração do ano

O intervalo de anos é definido através de `int ano = rnd.Next(1950, 2016);`. Nesse caso, são gerados anos de **1950 até 2015**. Isso acontece porque o limite superior do `Random.Next()` é exclusivo.

Caso seja necessário incluir o ano de 2016: `int ano = rnd.Next(1950, 2017);`.

---

### 2. Geração do mês

O mês é gerado entre 1 e 12: `int mes = rnd.Next(1, 13);`. O `13` é utilizado porque o limite superior do `Random.Next()` não é incluído.

Assim, os valores possíveis são:

```text
1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
```

---

### 3. Identificação do último dia do mês

Para evitar a geração de datas inválidas, o método utiliza:

```csharp
int ultimoDia =
    DateTime.DaysInMonth(ano, mes);
```

Esse método retorna a quantidade correta de dias para o mês informado.

Por exemplo:

```text
Fevereiro → 28 ou 29
Abril     → 30
Maio      → 31
```

Isso também considera automaticamente anos bissextos.

---

### 4. Geração do dia

Depois de descobrir quantos dias existem naquele mês: `int dia = rnd.Next(1, ultimoDia + 1);`. Dessa forma, o dia sempre estará dentro de um intervalo válido.

* Para um mês com 31 dias: **1 até 31**
* Para um mês com 30 dias: **1 até 30**

---

### 5. Criação da data

Finalmente, os valores são utilizados para criar um `DateTime`: `return new DateTime(ano, mes, dia);` (o resultado é uma data válida).

---

## Veja o método funcionando

**[gerar_data_aleatoria.cs](./scripts/gerar_data_aleatoria.cs)**

Durante a execução, o teste:

1. Inicializa o Chrome;
2. Acessa a página definida no teste;
3. Executa GerarData();
4. Retorna um DateTime;
5. Exibe a data em um alert.
Exemplo:

```text
Data gerada: 15/07/1998
```

Na próxima execução, outra data poderá ser gerada.

---

## Utilizando a data em um campo

Como `GerarData()` retorna um `DateTime`, quando a data precisar ser enviada para um campo do navegador, é necessário convertê-la para uma representação textual.

```csharp
string data = GerarData().ToString("dd/MM/yyyy");

driver.FindElement(By.Id("MainContent_txtDataNascimento"))
    .SendKeys(data);
```

Também é possível armazenar o valor em uma variável antes de utilizá-lo:

```csharp
DateTime dataGerada = GerarData();

driver.FindElement(By.Id("MainContent_txtDataNascimento"))
    .SendKeys(dataGerada.ToString("dd/MM/yyyy"));
```

> 💡 Por que utilizar `ToString("dd/MM/yyyy")`? </p>
O formato explícito evita depender da configuração regional do computador; em vez de `Convert.ToString(GerarData())`, é preferível definir explicitamente o formato esperado pelo campo `GerarData().ToString("dd/MM/yyyy")`. Isso é especialmente importante quando o sistema espera uma data no formato brasileiro.

---

## Exemplo aplicado a um cadastro

Supondo que o sistema possua um campo de data de nascimento:

```csharp
DateTime dataNascimento = GerarData();

driver.FindElement(
    By.Id("MainContent_txtDataNascimento")
)
.SendKeys(
    dataNascimento.ToString("dd/MM/yyyy")
);
```

Nesse caso, o teste gera a data e imediatamente a utiliza no formulário.

---

## Por que gerar datas aleatórias?

A geração dinâmica de datas pode ser útil para testes que precisam:

* preencher campos de data;
* testar cadastros;
* gerar datas de nascimento;
* testar diferentes valores;
* evitar dados fixos;
* criar massas de teste dinamicamente;
* validar regras relacionadas a datas.

Por exemplo, em um cadastro:

```text
Nome:             João da Silva
CPF:              12345678909
Data nascimento:  15/07/1998
```

A data pode ser gerada automaticamente pelo teste em vez de permanecer fixa.

---

## Evolução do exemplo

Em um projeto maior, o método `GerarData()` pode ser movido para uma **classe externa de utilidades**, assim como o gerador de CPF.

```text
Utils
├── GeraCPF.cs
└── GeraData.cs
```

A classe de teste passa então a consumir o método:

```csharp
GeraData gerador = new GeraData();

DateTime data = gerador.GerarData();
```

Essa abordagem evita duplicar o mesmo código em vários testes e facilita a manutenção dos geradores de dados.

---

## 🎯 Objetivo do repositório

Este exemplo faz parte da série de exemplos de **Selenium WebDriver com C#** deste repositório. Como o estudo da ferramenta é incremental, novos exemplos podem ser adicionados conforme novos recursos forem explorados. A ideia é manter os códigos como uma **referência rápida** para funcionalidades que podem ser reutilizadas em diferentes scripts de automação.

## 🤝 Contribuições

Sugestões, melhorias e novos exemplos são bem-vindos! Caso você tenha alguma dúvida, sugestão ou queira contribuir com o projeto, fique à vontade para entrar em contato.

## 📌 Observação

Este repositório foi criado inicialmente como material de estudo e referência pessoal durante o aprendizado do Selenium WebDriver com C#. Os exemplos aqui apresentados representam funcionalidades que foram exploradas e utilizadas em automações, podendo ser adaptados conforme a necessidade de cada projeto.

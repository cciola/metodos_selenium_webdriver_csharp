# Gerador de data aleatória

Este exemplo demonstra como criar um método para **gerar datas aleatórias válidas** para utilização em testes automatizados com Selenium WebDriver. A cada execução do método `GerarData()`, uma nova data é criada dentro do intervalo definido no código. Esse tipo de recurso é útil para gerar **dados de teste dinamicamente**, evitando a necessidade de utilizar sempre os mesmos valores. Um gerador de datas é especialmente útil quando o teste precisa trabalhar com **dados variáveis**.

## Explicação detalhada

📜 **[GerarData.cs](./scripts/GerarData.cs)**

O método utiliza a classe `Random` para definir aleatoriamente (**ano**, **mês** e **dia**), e retorna um objeto `DateTime`: `15/07/1998`.

**1. Geração do ano** - O intervalo de anos é definido através de `int ano = rnd.Next(1950, 2016);`. Nesse caso, são gerados anos de **1950 até 2015**. Isso acontece porque o limite superior do `Random.Next()` é exclusivo. Caso seja necessário incluir o ano de 2016: `int ano = rnd.Next(1950, 2017);`.

**2. Geração do mês** - O mês é gerado entre 1 e 12: `int mes = rnd.Next(1, 13);`. O `13` é utilizado porque o limite superior do `Random.Next()` não é incluído. Assim, os valores possíveis são: `1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12`.

**3. Identificação do último dia do mês** - Para evitar a geração de datas inválidas, o método utiliza `int ultimoDia = DateTime.DaysInMonth(ano, mes);`. Esse método retorna a quantidade correta de dias para o mês informado, exemplo: **Fevereiro (28 ou 29)**, **Abril (30)**, **Maio (31)**. Isso também considera automaticamente **anos bissextos**.

**4. Geração do dia** - Depois de descobrir quantos dias existem naquele mês: `int dia = rnd.Next(1, ultimoDia + 1);`. Dessa forma, o dia sempre estará dentro de um intervalo válido: para um mês com 31 dias: **1 até 31**, para um mês com 30 dias: **1 até 30**.

**5. Criação da data** - Finalmente, os valores são utilizados para criar um `DateTime`: `return new DateTime(ano, mes, dia);` (o resultado é uma data válida).

## Veja o método funcionando

📜 **[gerar_data_aleatoria.cs](./scripts/gerar_data_aleatoria.cs)**

Durante a execução, o teste:

1. Inicializa o Chrome;
2. Acessa a página definida no teste;
3. Executa GerarData();
4. Retorna um DateTime;
5. Exibe a data em um alert.

Exemplo de texto exibido no alert:

```text
Data gerada: 15/07/1998
```

Na próxima execução, outra data poderá ser gerada. Como `GerarData()` retorna um `DateTime`, quando a data precisar ser enviada para um campo do navegador, é necessário convertê-la para uma representação textual.

```csharp
string data = GerarData().ToString("dd/MM/yyyy");
driver.FindElement(By.Id("MainContent_txtDataNascimento")).SendKeys(data);
```

Também é possível armazenar o valor em uma variável antes de utilizá-lo:

```csharp
DateTime dataGerada = GerarData();
driver.FindElement(By.Id("MainContent_txtDataNascimento")).SendKeys(dataGerada.ToString("dd/MM/yyyy"));
```

Utilizamos `ToString("dd/MM/yyyy")`, pois o formato explícito evita depender da configuração regional do computador; em vez de `Convert.ToString(GerarData())`, é preferível definir explicitamente o formato esperado pelo campo `GerarData().ToString("dd/MM/yyyy")`. Isso é especialmente importante quando o sistema espera uma data no formato brasileiro.

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

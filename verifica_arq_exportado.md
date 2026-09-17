# Verificador de exportação de arquivo

Este exemplo apresenta um método responsável por verificar se um determinado arquivo foi baixado após uma operação no sistema, como o clique em um botão de **Download** ou **Exportar**.

A implementação utiliza **C#**, **Selenium WebDriver** e o conceito de **Programação Orientada a Objetos (POO)**, separando a implementação do método da classe principal que executa o teste.

---

## Quando utilizar

Este método pode ser utilizado em testes automatizados que precisem validar funcionalidades de:

- Download de arquivos.
- Exportação de relatórios.
- Geração de documentos.
- Exportação de dados em diferentes formatos.
- Impressão ou geração de arquivos a partir da aplicação.
- Funcionalidades em que o resultado esperado seja a criação de um arquivo no computador.

> 💡 A abordagem é especialmente útil quando o teste precisa confirmar não apenas que o botão foi clicado, mas que o arquivo esperado foi efetivamente gerado e disponibilizado na pasta de downloads.

---

## Estrutura

A implementação é dividida em duas classes:

* `principal.cs` — classe responsável pela execução do teste e chamada do método.
* `exportacao.cs` — classe que contém o método responsável por verificar o download do arquivo.

---

## 📜 exportacao.cs

**[exportacao.cs](./scripts/exportacao.cs)**

O método `VerificaArquivoBaixado` recebe o nome do arquivo que deverá ser gerado e retorna um valor booleano indicando se o download foi realizado com sucesso.


### Retorno do método

O método é público e retorna um `bool`, portanto seu resultado será:

- `true` quando o arquivo esperado for encontrado
- `false` quando o arquivo não for encontrado

O parâmetro `nomeArquivo` recebe o nome do arquivo que deverá ser gerado, **sem a extensão**.

Inicialmente, a variável `existe` recebe `false`, partindo do princípio de que o arquivo ainda não foi encontrado.

```csharp
public bool VerificaArquivoBaixado(string nomeArquivo)
{
    bool existe = false;
```

### Localização da pasta Downloads

O trecho abaixo obtém o caminho do perfil do usuário da máquina e, a partir dele, monta o caminho da pasta `Downloads`.

A variável `pathDownload` passa a representar o caminho utilizado para localizar os arquivos baixados durante a execução do teste.

```csharp
string pathUser = Environment.GetFolderPath(
    Environment.SpecialFolder.UserProfile
);

string pathDownload = Path.Combine(pathUser, @"Downloads\");
```

### Remoção de arquivo existente

Antes de realizar o download, o arquivo que possui o mesmo nome esperado é **removido**. Essa etapa é importante para evitar que o teste encontre um arquivo de uma execução anterior e interprete incorretamente que o download atual foi realizado com sucesso.

**Observação:** não é necessário limpar todo o conteúdo da pasta `Downloads`. Apenas o arquivo que será utilizado pelo teste é removido.

```csharp
File.Delete(pathDownload + nomeArquivo + ".pdf");
```

### Execução do download

Em seguida, o Selenium localiza o botão responsável pelo download e realiza o clique; nesse ponto, o sistema deve iniciar a geração e o download do arquivo.

```csharp
IWebElement btnDownload = driver.FindElement(By.Id("idBotao"));
btnDownload.Click();
```

### Verificação do arquivo

Após o clique, o método obtém os arquivos existentes na pasta `Downloads`.

A variável `filePaths` recebe os caminhos dos arquivos encontrados no diretório.

Depois, o `foreach` percorre esses arquivos:

```csharp
string[] filePaths = Directory.GetFiles(pathDownload);
```

```csharp
foreach (string p in filePaths)
{
    if (p.Contains(nomeArquivo + ".pdf"))
    {
        existe = true;

        File.Delete(pathDownload + nomeArquivo + ".pdf");

        break;
    }
}
```

Para cada arquivo encontrado, o `if` verifica se o caminho contém o nome esperado juntamente com a extensão `.pdf`.

### Arquivo encontrado

Quando o arquivo é encontrado:

1. A variável `existe` recebe `true`.
2. O arquivo gerado pelo teste é excluído.
3. O `break` encerra a busca.
4. O método retorna `true`.

A exclusão do arquivo evita que ele permaneça na pasta `Downloads` e interfira em execuções futuras.

### Arquivo não encontrado

Caso nenhum arquivo correspondente seja encontrado, a variável `existe` permanece `false`. Nesse caso, o trecho abaixo identifica a falha:

```csharp
if (existe == false)
{
    driver.Quit();
}
```

O navegador é encerrado, e o método retorna `false`.

```csharp
return existe;
```

---

## 📜 principal.cs

Na classe principal, basta informar o nome esperado do arquivo e chamar o método:

```csharp
string nomeArquivo = "NomeDoArquivoExportado"; // nome do arquivo sem extensão

exporta.VerificaArquivoBaixado(nomeArquivo);
```

O valor informado em `nomeArquivo` deve corresponder ao nome do arquivo que o sistema deverá gerar, **sem a extensão `.pdf`**. Por exemplo:

```csharp
string nomeArquivo = "RelatorioClientes";

exporta.VerificaArquivoBaixado(nomeArquivo);
```

Nesse caso, o método procurará pelo arquivo `RelatorioClientes.pdf` na pasta `Downloads` do usuário.

---

## Fluxo da validação

De forma resumida, o processo executado pelo método é:

```text
Início
  │
  ├── Obtém a pasta Downloads
  ├── Remove arquivo anterior com o mesmo nome
  ├── Clica no botão de Download
  ├── Lista os arquivos da pasta Downloads
  ├── Procura pelo arquivo esperado
  ├── Arquivo encontrado?
  │       │
  │       ├── Sim → define existe = true
  │       │          → exclui o arquivo
  │       │          → retorna true
  │       │
  │       └── Não → mantém existe = false
  │                  → encerra o navegador
  │                  → retorna false
  │
  └── Fim
```

> **💡 Observação**: O exemplo utiliza `Thread.Sleep(1000)` para aguardar a geração do arquivo. Em aplicações reais, essa abordagem pode ser substituída por uma estratégia de espera mais robusta, especialmente quando o tempo de geração do arquivo pode variar. O objetivo deste exemplo é demonstrar a lógica de validação da exportação e a separação do método em uma classe própria, seguindo o conceito de POO.

---

## 🎯 Objetivo do repositório

Este exemplo faz parte da série de exemplos de **Selenium WebDriver com C#** deste repositório. Como o estudo da ferramenta é incremental, novos exemplos podem ser adicionados conforme novos recursos forem explorados. A ideia é manter os códigos como uma **referência rápida** para funcionalidades que podem ser reutilizadas em diferentes scripts de automação.

## 🤝 Contribuições

Sugestões, melhorias e novos exemplos são bem-vindos! Caso você tenha alguma dúvida, sugestão ou queira contribuir com o projeto, fique à vontade para entrar em contato.

## 📌 Observação

Este repositório foi criado inicialmente como material de estudo e referência pessoal durante o aprendizado do Selenium WebDriver com C#. Os exemplos aqui apresentados representam funcionalidades que foram exploradas e utilizadas em automações, podendo ser adaptados conforme a necessidade de cada projeto.

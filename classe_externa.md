# Criar classe externa

Para evitar que o código-fonte do projeto fique muito extenso, é possível **separar funcionalidades em classes externas** e reutilizar seus métodos nos scripts de teste.

Essa abordagem ajuda a organizar o projeto, facilita a manutenção e permite reutilizar métodos em diferentes testes.

---

## ⚡ Quando utilizar?

A criação de classes externas é especialmente útil quando o projeto começa a acumular:

* métodos auxiliares;
* geração de dados de teste;
* funções reutilizáveis;
* regras de negócio utilizadas por vários testes;
* funcionalidades que não pertencem diretamente ao cenário de teste.

Em um projeto de automação maior, essa organização pode evoluir para uma estrutura com **classes utilitárias, Page Objects e componentes reutilizáveis**, evitando que os scripts de teste concentrem responsabilidades demais.

---

## 📋 Criando uma classe externa

No **Solution Explorer**, clique com o botão direito do mouse sobre o nome do projeto e selecione **Add → Class... → Class**, informe o nome da classe e confirme a criação, exemplo `GeraCPF.cs`.

No arquivo da classe, o `namespace` deve corresponder ao namespace utilizado pelo projeto: `namespace NomeDoProjeto`.

A classe deve ser declarada como `public` para que possa ser acessada por outros arquivos: `public class GeraCPF`.

---

## 📁 Organizando a classe em uma pasta própria

No **Solution Explorer**:

1. Clique com o botão direito no nome do projeto.
2. Selecione **Add → New Folder**.
3. Informe o nome da pasta.
4. Arraste o arquivo `.cs` criado para dentro da pasta.

A pasta pode ter o mesmo nome da classe, por exemplo:

```text
GeraCPF
└── GeraCPF.cs
```

> ** Observação:** a criação da pasta é apenas uma forma de organização. O que permite utilizar a classe em outro arquivo é principalmente o `namespace`, a visibilidade `public` e a referência correta à classe.

---

## 🔗 Importando a classe no teste

No arquivo que utilizará a classe externa, inclua o `namespace` correspondente: `using NomeDoProjeto;`.

Depois, instancie a classe: `GeraCPF gerador = new GeraCPF();`.

A partir da instância criada, o método da classe pode ser chamado normalmente: `gerador.GerarCpf();`.

### Exemplo da estrutura

```text
NomeDoProjeto
│
├── GeraCPF
│   └── GeraCPF.cs
│
└── Testes
    └── Teste.cs
```

---

# 🧪 Veja o método funcionando

Neste exemplo, será criada uma classe externa chamada `GeraCPF`. Ela possui o método `GerarCpf()`, responsável por gerar um CPF válido de forma aleatória.

> [GeraCPF.cs](./scripts/GeraCPF.cs)

O ponto principal desse exemplo é que a lógica para geração do CPF fica isolada na classe `GeraCPF`.

Assim, o teste não precisa conhecer os detalhes de como o CPF é calculado. Ele apenas chama `gerador.GerarCpf();`.

---

## ▶️ Utilizando a classe no teste

No script de teste, importe o namespace da classe: `using AW_cadastroPaciente;`.

Depois, crie uma instância: `GeraCPF gerador = new GeraCPF();`.

O método pode então ser utilizado no teste: `gerador.GerarCpf();`.

### Exemplo completo

> [classe_externa.cs](./scripts/classe_externa.cs)

---

## 🔄 O que acontece durante a execução?

O fluxo do teste é:

```text
Teste
  │
  ├── Cria uma instância de GeraCPF
  │
  ├── Acessa a página definida em baseURL
  │
  ├── Localiza o campo
  │
  ├── Chama gerador.GerarCpf()
  │       │
  │       └── Classe externa gera o CPF
  │
  └── Digita o CPF no campo
```

Dessa forma, a responsabilidade fica separada:

**Classe `GeraCPF`** → responsável pela lógica de geração do CPF.

**Classe de teste** → responsável pela interação com o navegador e pela execução do cenário.

---

## 💡 Por que utilizar classes externas?

Separar funcionalidades em classes externas pode trazer algumas vantagens:

* **Organização:** evita concentrar toda a lógica em um único arquivo.
* **Reutilização:** o mesmo método pode ser utilizado em vários testes.
* **Manutenção:** alterações ficam concentradas na classe responsável pela funcionalidade.
* **Legibilidade:** o teste fica mais simples de entender.
* **Separação de responsabilidades:** cada classe pode ter uma finalidade específica.

Por exemplo, métodos para gerar dados de teste podem ficar separados:

```text
Utils
├── GeraCPF.cs
├── GeraData.cs
└── GeraEmail.cs
```

Os testes podem reutilizar essas funcionalidades sempre que necessário.

---

## 🎯 Objetivo do repositório

Este exemplo faz parte da série de exemplos de **Selenium WebDriver com C#** deste repositório.

Como o estudo da ferramenta é incremental, novos exemplos podem ser adicionados conforme novos recursos forem explorados.

A ideia é manter os códigos como uma **referência rápida** para funcionalidades que podem ser reutilizadas em diferentes scripts de automação.

---

## 🤝 Contribuições

Sugestões, melhorias e novos exemplos são bem-vindos! Caso você tenha alguma dúvida, sugestão ou queira contribuir com o projeto, fique à vontade para entrar em contato.

---

## 📌 Observação

Este repositório foi criado inicialmente como material de estudo e referência pessoal durante o aprendizado do Selenium WebDriver com C#. Os exemplos aqui apresentados representam funcionalidades que foram exploradas e utilizadas em automações, podendo ser adaptados conforme a necessidade de cada projeto.

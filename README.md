# Demo Fluxo de caixa

> Projeto de API demo de fluxo de caixa para entrada e saída de valores e geração de relatório consolidado por datas.

### Projeto desenvolvido usando Minimal API:

- C# (.Net Core versão: 6.0.401)
- Sqlite versão: 6.0.10
- Entity Framework versão: 6.0.10
- MiniValidation versão: 0.6.0-pre.20220527.55

## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:

- Você instalou a versão mais recente de `<linguagem / dependência / requeridos>`
- Você tem uma máquina `<Windows / Linux / Mac>`.

## 🚀 Instalando `FluxoCaixa`

- Abrir o terminal e executar o comando abaixo:

```
$ git clone https://github.com/shagost/DemoMinimalApi.git
```

> Obs.: Alternativamente você pode clicar em `Code` e `Download ZIP`, descompactar em uma pasta, acessar a pasta pelo terminal e abrir o VSCode com o comando (ou uma IDE de sua escolha):

```
$ code .
```

- Executar os comandos:

```
$ dotnet restore
$ dotnet build
```

- Executar a migração:

```
$ dotnet ef migrations add Fluxo
$ dotnet ef database update
```

## ☕ Rodando o `FluxoCaixa`

Para usar o FluxoCaixa, siga estas etapas:

No terminal, digite:

```
$ dotnet run
```

Acessar a url https://localhost:7271/swagger

Observar se a porta está correta com a da sua máquina.

Irá abrir a página do Swagger, ou caso queira, poderá utilizar um aplicativo como o `Postman`.

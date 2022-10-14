# Demo Fluxo de caixa

![GitHub repo size](https://img.shields.io/github/repo-size/shagost/README-template?style=for-the-badge)

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

## 🚀 Instalando `<FluxoCaixa>`

- Abrir o terminal e executar o comando abaixo:

```
$ git clone https://github.com/shagost/DemoMinimalApi.git
```

> Obs.: Alternativamente você pode clicar em `Code` e `Download ZIP`, descompactar em uma pasta, acessar a pasta pelo terminal e abrir o VSCode com o comando

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

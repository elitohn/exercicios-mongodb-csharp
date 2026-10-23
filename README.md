<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&height=175&color=0:0F172A,55:164E63,100:0891B2&text=Exerc%C3%ADcios%20MongoDB&fontColor=FFFFFF&fontSize=34&fontAlignY=38&desc=C%23%20%7C%20MongoDB.Driver&descAlignY=61&descSize=15" alt="Capa do projeto Exercícios MongoDB" width="100%" />

![Tecnologia](https://img.shields.io/badge/C%23%20%26%20MongoDB-0F172A?style=flat-square) ![Idioma](https://img.shields.io/badge/documentação-pt--BR-0891B2?style=flat-square) ![Tipo](https://img.shields.io/badge/projeto-de%20estudo-334155?style=flat-square)

</div>

# 🧩 Exercícios MongoDB com C#

Conjunto de exercícios em **C#** para praticar integração com o MongoDB. O conteúdo inclui operações CRUD, modelagem e serialização de documentos BSON, consultas, agregações, validação de schema e criação de índices.

## Conteúdo

- Criação de bancos, coleções e documentos;
- Conversão entre objetos C#, JSON e BSON;
- Inserção, atualização, consulta e remoção de notícias;
- Filtros por data, tag, jornalista e palavra-chave;
- Agregações e cálculo de estatísticas;
- Validação de documentos com JSON Schema;
- Índices simples e compostos para consultas.

## Tecnologias

- C#
- .NET 10
- MongoDB.Driver
- Newtonsoft.Json
- MongoDB Atlas

## Estrutura do projeto

```text
exercicios-mongodb-csharp/
├── CursoMongoDB/
│   ├── .env.example    # exemplo de configuração
│   ├── .gitignore
│   ├── Contexts/       # Contexto e configuração de conexão
│   ├── Models/         # Notícias, jornalistas, comentários e anexos
│   ├── Programs/       # Exercícios separados por aula
│   ├── Services/       # Operações e consultas MongoDB
│   ├── data/           # Dados fictícios de demonstração
│   ├── Program.cs      # Seleção do exercício a executar
│   └── CursoMongoDB.csproj
└── README.md
```

## Como executar

### Pré-requisitos

É necessário ter o **.NET 10 SDK** e uma instância MongoDB local ou no Atlas.

Confira a instalação do SDK:

```bash
dotnet --version
```

### Configurar a conexão

Defina a variável de ambiente `MONGODB_URI` com a sua URI de conexão. Não coloque credenciais reais no código ou em commits.

PowerShell:

```powershell
$env:MONGODB_URI = "mongodb+srv://USUARIO:SENHA@SEU-CLUSTER/"
```

Bash:

```bash
export MONGODB_URI='mongodb+srv://USUARIO:SENHA@SEU-CLUSTER/'
```

### Executar um exercício

```bash
cd CursoMongoDB
dotnet restore
dotnet build
dotnet run -- 10_5
```

A execução sem informar um exercício apenas exibe as instruções e não conecta ao banco:

```bash
dotnet run
```

Os exercícios são selecionados pelo identificador da aula:

```text
2_4, 2_5
3_1a, 3_1b, 3_2, 3_3, 3_5
4_1, 4_2, 4_3, 4_4a, 4_4b, 4_5a, 4_5b
5_2a, 5_2b, 5_3a, 5_3b
6_2a, 6_2b, 6_3, 6_5, 6_6
7_1, 7_2, 7_3, 7_4
8_1, 8_2, 8_3, 8_4, 8_5
9_1, 9_2, 9_3, 9_4
10_1, 10_3, 10_5
```

Os exercícios de importação utilizam o arquivo fictício `data/noticias.example.json`.

## Schema e índices

A configuração de schema e do índice único para `Url` é explícita. Para executá-la:

```bash
dotnet run -- --setup
```

Esse comando altera a coleção `noticias` no banco `NoticiasDB`. Se já existirem URLs duplicadas, a criação do índice único poderá falhar; revise os dados antes.

## Atenção às operações destrutivas

O exercício `3_1b` apaga o banco `NoticiasDB` inteiro e exige confirmação digitando `APAGAR`. Use-o somente em um banco descartável.

## Objetivo

Praticar os principais recursos do MongoDB usando C# e o driver oficial do .NET.

Desenvolvido por **Wellyton Huan**.

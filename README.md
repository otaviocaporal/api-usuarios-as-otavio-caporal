# API de Gerenciamento de Usuários

  

## Descrição

O projeto se trata de uma API de Gerenciamento de Usuários, onde é possível cadastrar usuários únicos através de identificadores como ID e Email. 

A aplicação foi construída como atividade prática da disciplina de Desenvolvimento Backend, com foco no uso de camadas bem definidas, validação, padrões de projeto e persistência de dados. Ela demonstra conceitos essenciais de desenvolvimento backend moderno com .NET, como DTOs, Services, Repository Pattern e Entity Framework Core.

Além disso, a API utiliza SQLite como banco de dados, permitindo uma fácil usabilididade e execução sem necessidade de instalar SGBDs externos.

## Tecnologias Utilizadas

- Linguagem C# 12.0

- .NET 9.0 ou superior

- Entity Framework Core 8.0 ou superior

- SQLite

- FluentValidation

- Clean Architecture (não uma ferramenta, mas uma forma de organizar a estrutura de forma limpa)

- Swagger
  

## Padrões de Projeto Implementados

- Repository Pattern - acessar os dados e realizar testes

- Service Pattern - regras de negócio e validações

- Factory Pattern - usado para criação de usuários de forma segura e sem erros

- DTO Pattern - separa dados de entrada e saída enviados e recebidos por usuários

- Dependency Injection - integração entre serviços, repositórios e controllers


## Como Executar o Projeto

  Primeiramente, deve ter instalado o .NET SDK na versão 8.0+, além do Git (Bash) ;
  Abra o Git e clone o repositório, inserindo o comando " git clone https://github.com/otaviocaporal/api-usuarios-as-otavio-caporal.git " (sem as aspas), assim criando uma pasta com todo o projeto dentro ;
  Abra o terminal do próprio Windows (cmd) na pasta do projeto, envie o comando " dotnet ef database update " para executar as migrations, e depois " dotnet run " para rodar a API ;
  É possível usar o Postman para testar endpoints ;


### Pré-requisitos

- *OBS: O projeto foi realizado com .NET na versão 9.0.304, Entity Framework Core .NET Command-line Tools (dotnet ef) na versão 8.0.6;
- .NET SDK 8.0 ou superior
- Ferramenta dotnet ef instalada (versão 8.0.6) -> dotnet tool install --global dotnet-ef --version 8.0.6

- Instale o Postman para testar endpoints (GET, POST, PUT, DELETE...)
- A API estará disponível em http://localhost:5216
- utilize http://localhost:5216/usuarios para métodos GET (listar todos usuários) e POST (criar usuário)
- utilize http://localhost:5216/usuarios/{id} para métodos GET (buscar usuário por ID), PUT (atualizar usuário por ID) e DELETE (soft delete usuário por ID)
  

### Passos

1. Clone o repositório - git clone https://github.com/otaviocaporal/api-usuarios-as-otavio-caporal.git

2. Execute as migrations - dotnet ef database update

3. Execute a aplicação - dotnet run

  

### Exemplos de Requisições
JSON: 
POST
{
  "nome": "Seu Nome",
  "email": "seuemail@exemplo.com",
  "senha": "123456",
  "dataNascimento": "2000-01-01",
  "telefone": "(51)99999-9999"
}
PUT
{ 
  "id": 10,
  "nome": "Your name",
  "email": "youremail@exemplo.com",
  "dataNascimento": "2007-02-25",
  "telefone": "(51)98888-8888",
  "ativo": true
}
GET - http://localhost:5216/usuarios // por ID - http://localhost:5216/usuarios/1
DELETE por ID - http://localhost:5216/usuarios/1
  

## Estrutura do Projeto

Organizada com Clean Architecture, com pastas separando códigos em conjunto e do mesmo tipo de função.

APIUsuarios/
├── Domain/
│ └── Entities/
│ └── Usuario.cs
│
├── Application/
│ ├── DTOs/
│ │ ├── UsuarioCreateDto.cs
│ │ ├── UsuarioReadDto.cs
│ │ └── UsuarioUpdateDto.cs
│ │
│ ├── Interfaces/
│ │ ├── IUsuarioRepository.cs
│ │ └── IUsuarioService.cs
│ │
│ ├── Services/
│ │ └── MappingExtensions.cs
│ │ └── UsuarioFactory.cs
│ │ └── UsuarioService.cs
│ │
│ └── Validators/
│ ├── UsuarioCreateDtoValidator.cs
│ └── UsuarioUpdateDtoValidator.cs
│
├── Infrastructure/
│ ├── Persistence/
│ │ └── AppDbContext.cs
│ │
│ └── Repositories/
│ └── UsuarioRepository.cs
│
├── Migrations/
│ └── (geradas automaticamente)
│
├── Program.cs
├── appsettings.json
└── APIUsuarios.csproj

  

## Autor

Otávio Brocca Caporal

RA: 2025001077

Curso: Análise e Desenvolvimento de Sistemas

link do vídeo no youtube: https://youtu.be/kVDhYD1YUgQ 
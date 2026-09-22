# Rede Raízes do Nordeste

API Back-End desenvolvida para a Rede Raízes do Nordeste.

## Sobre o projeto

O projeto tem como objetivo desenvolver uma API Back-End para a Rede Raízes do Nordeste, permitindo a 
integração dos diferentes canais de atendimento e centralizando regras relacionadas a usuários, unidades, 
cardápios, pedidos, estoque e pagamentos de forma profissional.

O MVP será desenvolvido com foco no fluxo de realização de pedidos, contemplando autenticação, 
seleção da unidade, consulta ao cardápio mediante disponibilidade da unidade, criação do pedido, pagamento simulado e atualização de status.

## Tecnologias Utilizadas

- C#
- .NET 10
- ASP.NET Core
- PostgreSQL
- Entity Framework Core
- JWT
- OpenAPI / Swagger
- Postman
- Git / GitHub

## Pré-requisitos

Para executar o projeto localmente é necessário possuir:

- .NET SDK 10
- PostgreSQL
- Git
- Uma IDE ou editor compatível com .NET, como Visual Studio, Visual Studio Code ou Rider

### Para verificar a instalação do .NET

```powershell
dotnet --version
```

### Para verificar a instalação do PostgreSQL através do psql

```powershell
psql --version
```

### Para verificar a instalação do Git

```powershell
git --version
```

## Configuração inicial

Após clonar o repositório, acesse a pasta raiz do projeto.

### Restaure as dependências da solução

```powershell
dotnet restore
```

### Restaure as ferramentas locais do projeto

```powershell
dotnet tool restore
```

O projeto utiliza o `dotnet-ef` como ferramenta local, definido através do arquivo `dotnet-tools.json`.

### Para verificar se a ferramenta está disponível

```powershell
dotnet ef --version
```

## Configuração do banco de dados

O projeto utiliza PostgreSQL.

A connection string utilizada pela aplicação possui o nome:

`DefaultConnection`

Por segurança, credenciais locais não devem ser armazenadas diretamente no repositório.

Na pasta raiz do projeto, configure a connection string utilizando .NET User Secrets:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=raizes_nordeste;Username=postgres;Password=SUA_SENHA" --project src/RaizesNordeste.Api
```

Substitua `SUA_SENHA` pela senha configurada para o usuário PostgreSQL no ambiente local.

Para verificar os secrets configurados:

```powershell
dotnet user-secrets list --project src/RaizesNordeste.Api
```

## Arquitetura

O Back-End está organizado nos seguintes projetos, de acordo com os solicitados nos documentos do trabalho:

- `RaizesNordeste.Api`
- `RaizesNordeste.Application`
- `RaizesNordeste.Domain`
- `RaizesNordeste.Infrastructure`

## Banco de Dados

A aplicação utiliza PostgreSQL como banco de dados relacional e Entity Framework Core para o mapeamento objeto-relacional e gerenciamento das migrations.

A estrutura inicial do banco é composta pelas seguintes tabelas:

| Tabela | Responsabilidade |
|---|---|
| `Perfil` | Define os perfis de acesso disponíveis aos usuários do sistema. |
| `Usuario` | Armazena os usuários da aplicação, incluindo clientes, funcionários e usuários administrativos. |
| `Unidade` | Representa as unidades da Rede Raízes do Nordeste. |
| `Produto` | Armazena os produtos comercializados pela rede. |
| `Cardapio` | Representa o cardápio associado a uma unidade. |
| `CardapioItem` | Relaciona os produtos disponíveis em determinado cardápio. |
| `Pedido` | Representa os pedidos realizados pelos clientes. |
| `PedidoItem` | Armazena os produtos e quantidades pertencentes a um pedido. |
| `Pagamento` | Armazena as informações relacionadas ao pagamento de um pedido. |
| `Estoque` | Representa o estoque associado a uma unidade. |
| `ItemInventario` | Representa os insumos controlados pelo estoque. |
| `SaldoEstoque` | Mantém as quantidades disponíveis e reservadas de cada item do estoque. |
| `Receita` | Representa a composição necessária para produção de um produto. |
| `ReceitaItem` | Relaciona uma receita aos itens de inventário utilizados em sua produção. |
| `ProdutoItemInventario` | Relaciona produtos diretamente aos itens de inventário consumidos. |
| `PontosCliente` | Mantém o saldo de pontos associado ao cliente. |
| `PontosHistorico` | Registra as movimentações realizadas no saldo de pontos do cliente. |
| `RegraResgatePontos` | Define as regras para utilização dos pontos acumulados. |
| `Consentimento` | Registra os consentimentos fornecidos pelos usuários. |
| `Auditoria` | Registra operações relevantes realizadas no sistema para fins de rastreabilidade. |

### Persistência

Os dados da aplicação são persistidos em PostgreSQL. O projeto não utiliza banco de dados em memória para armazenamento dos dados da aplicação.

O Entity Framework Core é responsável pelo mapeamento das entidades e pela evolução da estrutura do banco através de migrations.

### Dados iniciais

A aplicação possui dados estruturais criados através das migrations.

Atualmente são criados os seguintes perfis:

| Id | Perfil |
|---:|---|
| 1 | Sistema |
| 2 | Administrador |
| 3 | Funcionário |
| 4 | Cliente |

O perfil `Sistema` é destinado à identificação de operações automáticas executadas pela própria aplicação.

Os demais perfis representam os principais tipos de usuários que utilizarão o sistema.

## Criação do banco de dados

Com o PostgreSQL em execução e a connection string configurada, aplique as migrations:

```powershell
dotnet ef database update --project src/RaizesNordeste.Infrastructure --startup-project src/RaizesNordeste.Api
```

O Entity Framework Core utilizará as migrations existentes para criar e configurar a estrutura necessária do banco de dados.

Atualmente o projeto possui as seguintes migrations:

- `InitialCreate` — cria a estrutura inicial do banco de dados;
- `SeedPerfis` — adiciona os perfis iniciais utilizados pela aplicação.

## Compilação

Para compilar toda a solução:

```powershell
dotnet build
```

A compilação deve ser concluída sem erros antes da execução da aplicação.

## Executando a aplicação

Para iniciar a API:

```powershell
dotnet run --project src/RaizesNordeste.Api
```

Após a inicialização, o terminal exibirá os endereços HTTP e HTTPS utilizados pela aplicação.

A documentação de configuração, execução, banco de dados, testes e utilização da API será complementada conforme o desenvolvimento do projeto.
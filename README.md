# Rede Raízes do Nordeste

API Back-End desenvolvida para a Rede Raízes do Nordeste.

## 1. Sobre o projeto

O projeto Rede Raízes do Nordeste consiste no desenvolvimento de uma API REST para atender às necessidades de integração e centralização das operações de uma rede de restaurantes
chamada "Raízes do Nordeste". A solução foi desenvolvida baseada nos documentos auxiliares disponibilizados no ambiente virtual.

**Contexto do problema:** A rede de restaurantes Raízes do Nordeste precisava de uma solução que pudesse atender ao seu crescimento recente, permitindo que suas operações ocorressem em um
ambiente controlado, seguro e unificado, com possibilidade de escalabilidade. 

**Objetivo da solução:** A API possui em sua infraestrutura um modelo relacional baseado nas informações disponibilizadas, permitindo que as operações estejam de acordo com as necessidades
apontadas, e considerando integração com front-end. A API então é reponsável por toda a validação dos dados enviados e seu tratamento, para garantir que a operação esteja de acordo
com as regras de negócio da rede Raízes do Nordeste.

**Escopo implementado:** O fluxo escolhido para implentação foi o FLUXO A. A partir disso, a modelagem da API foi inteiramente montada para atender às necessidades deste fluxo, que seguem
o seguinte caminho: Login do cliente ou funcionário; Realização de pedido; Confirmação de disponibilidade de estoque para o pedido; Alteração do status do pedido para "Aguardando Pagamento";
Processo de pagamento simulado, considerando futura implementação de sistema de pagamento externo; Alteração do status do pedido para Recebido, indicando que o pagamento foi efetuado; Mudança
de status do pedido definido por funcionários autorizados para "Em preparo", "Pronto" e "Entregue", seguindo ordem de sequência.

**Características adicionais:** A autorização dos usuários se dá através login com e-mail e senha. Esta não é armazenada em formato de texto padrão, mas em formato hash. Quando o usuário
digita a senha para efetuar o login, o hash é comparado ao valor armazenado no banco. Se confirmado, gera um token JWT válido por 60 minutos. Após essa validação é permitido ao usuários
acessar requisições autorizadas. Essas requisições são permitidas dependendo do Tipo de Usuário autenticado (Sistema, Admin, Funcionário ou Cliente).

## 2. Funcionalidades Implementadas

**Autenticação:** Realizada através de login com e-mail e senha, convertida em hash para validação; JWT e autorização por perfis (Sistema, Admin, Funcionário ou Cliente);
**Unidades e Cardápios:** Consultas realizadas por qualquer indivíduo, sem necessidade de login. É possível listar unidades ativas, e seus respectivos cardápios. Os produtos dos cardápios
aparecem conforme a disponibilidade do estoque;
**Pedidos:** A criação de pedidos pode ser feita tanto por cliente quanto por um funcionário autenticado, o campo de CanalPedido é obrigatório para criação, e cada pedido possui a informação de
quem o criou, considerando canais de realização do pedido. Logo, o pedido possui o ID do cliente + CriadoPor. Em um pedido pelo app, por exemplo, tanto ClienteId quanto CriadoPor receberão o ID
do usuário autenticado. Em caso de criação pelo balcão, o ClienteId permanece o mesmo, mas o CriadoPor recebe o ID do funcionário que realizou o pedido. A consulta de pedido pode ser realizada
e pode conter filtros. Cliente podem consultar apenas seus pedidos ou um pedido seu em específico. Funcionários podem consultar apenas pedidos realizados em sua unidade ou um pedido em específico
de sua unidade. Ao Admin é permitido consultar todos os pedidos, filtrando-os por Canal de Origem (APP, BALCAO, TOKEN, WEB ou PICK-UP) e por Status ("AguardandoPagamento", "Recebido", etc...).
**Pagamentos:** Simulação de aprovação ou recusa de Pagamentos;
**Usuários:** As funcionalidades relacionadas aos usuários permitem que o cliente se cadastre informando nome, e-mail, senha, CPF, data de nascimento. Um usuário Admin pode criar funcionários,
informando nome, e-mail, senha, CPF, data de nascimento, ID da unidade em que irá trabalhar e seu setor. Um usuário admin pode listar usuários do sistema, ou consultar um específico. O sistema
não permite exclusões de registros de usuários, de modo a manter os registros realizados pelos mesmos. Um usuário é criado sempre como ativo.
**Auditorias:** Operações de auditoria limitam-se a usuários do tipo Admin, que podem consultar dados gerados a partir de operações sensíveis. São registrados no momentos ações relacionadas a:
criação de pedidos, pagamentos (aprovados ou recusados) e mudanças nos status dos pedidos, de modo a acompanhar todo o histórico da operação desde o início.
**Consentimentos:** A API permite que um usuário CLIENTE registre seu consentimento relacionado às campanhas de promoções ou ao programa de fidelização. O cliente pode consultar todos os seus
consentimentos. Um usuário do tipo ADMIN pode consultar os consetimentos de vários clientes, ou de um cliente específico através do parâmetro de Id do cliente.

## 3. Tecnologias Utilizadas

**C# / .NET 10:** Linguagem e plataforma de desenvolvimento
**ASP.NET Core:** Implementação dos endpoints REST
**PostgreSQL 18:** Persistência relacional dos dados
**Entity Framework Core:** Mapeamento de entidades e migrations
**JWT Bearer:** Autenticação por token
**OpenAPI / Swagger:** Documentação e exploração dos endpoints
**Postman:** Execução de requisições e testes
**Git / GitHub:** Versionamento e disponibilização do código



## 4. Arquitetura da Aplicação

A estrutura da aplicação foi pensada de modo a separar as responsabilidades de cada camada da API de forma organizada, clara e condizente com os requisitos solicitados. A aplicação está organizada nas 
seguintes camadas:

**RaizesNordeste.Api:** Recebe requisições HTTP, expõe endpoints, configura autenticação/autorização e Swagger
**RaizesNordeste.Application:** Organiza os serviços e casos de uso, coordenando operações como criação de pedidos e pagamentos
**RaizesNordeste.Domain:** Contém as entidades e os conceitos centrais do negócio
**RaizesNordeste.Infrastructure:** Implementa o acesso ao PostgreSQL, o mapeamento do EF Core e as migrations


A API foi estruturada desta forma no intuito de separar as responsabilidades de cada camada da aplicação. Dessa forma, o sistema se torna mais organizado, e a manutenção se torna-se menos complexa.




## 5. Estrutura do Repositório

O repositório foi organizado de modo a facilitar a localização dos componentes utilizados, dividindo-os em três divisões principais:

**src:** Contém os quatro projetos que formam a solução back-end;
**postman:** Reúne a coleção de requisições e os cenários de testes utilizados;
**README.md:** Apresenta documentação técnica e instruções necessárias para execução da API, além de contextualização de decisões tomadas



## 6. Banco de Dados e Persistência

A aplicação utiliza o PostgreSQL 18 como banco de dados relacional e o Entity Framework Core para o mapeamento objeto-relacional e gerenciamento das migrations.

Os dados são armazenados de forma persistente no PostgreSQL, não sendo utilizado um banco de dados em memória para o armazenamento das informações da aplicação.

### 6.1 Estrutura do Banco de Dados

O modelo de dados da aplicação é composto pelas 20 tabelas a seguir:

- `Perfil`: Define os perfis de acesso disponíveis aos usuários do sistema. 
- `Usuario`: Armazena os usuários da aplicação, incluindo clientes, funcionários e usuários administrativos. 
- `Unidade`: Representa as unidades da Rede Raízes do Nordeste. 
- `Produto`: Armazena os produtos comercializados pela rede. 
- `Cardapio`: Representa o cardápio associado a uma unidade. 
- `CardapioItem`: Relaciona os produtos disponíveis em determinado cardápio. 
- `Pedido`: Representa os pedidos realizados pelos clientes. 
- `PedidoItem`: Armazena os produtos e quantidades pertencentes a um pedido. 
- `Pagamento`: Armazena as informações relacionadas ao pagamento de um pedido. 
- `Estoque`: Representa o estoque associado a uma unidade. 
- `ItemInventario`: Representa os insumos controlados pelo estoque. 
- `SaldoEstoque`: Mantém as quantidades disponíveis e reservadas de cada item do estoque. 
- `Receita`: Representa a composição necessária para produção de um produto. 
- `ReceitaItem`: Relaciona uma receita aos itens de inventário utilizados em sua produção. 
- `ProdutoItemInventario`: Relaciona produtos diretamente aos itens de inventário consumidos. 
- `PontosCliente`: Mantém o saldo de pontos associado ao cliente. 
- `PontosHistorico`: Registra as movimentações realizadas no saldo de pontos do cliente. 
- `RegraResgatePontos`: Define as regras para utilização dos pontos acumulados. 
- `Consentimento`: Registra os consentimentos fornecidos pelos usuários. 
- `Auditoria`: Registra operações relevantes realizadas no sistema para fins de rastreabilidade. 

As tabelas possuem relacionamentos que permitem representar as operações da rede, como a associação de usuários a pedidos, os itens que compõem cada pedido, seus pagamentos e o controle 
de estoque das unidades.

Além dessas 20 tabelas, o Entity Framework Core mantém a tabela técnica `__EFMigrationsHistory`, que é responsável pelo registro das migrations aplicadas ao banco de dados, 
totalizando 21 tabelas no esquema `public`.

### 6.2 Persistência e Migrations

O Entity Framework Core é utilizado para realizar o mapeamento das entidades e gerenciar a evolução da estrutura do banco de dados através de migrations.

As seguintes migrations foram identificadas como aplicadas ao banco `raizes_nordeste`:

- `20260922184214_InitialCreate`: Criação inicial da estrutura do banco de dados. 
- `20260922191221_SeedPerfis`: Inclusão dos perfis iniciais de acesso. 
- `20260923215043_SeedDadosIniciais`: Inclusão de dados iniciais da aplicação. 
- `20261001225858_AlterarFormaPagamentoParaEnum`: Alteração da representação da forma de pagamento para enum. 
- `20261005191238_AdicionarCpfDataNascimentoUsuario`: Inclusão dos campos CPF e data de nascimento nos dados dos usuários. 
- `20261006214235_SeedDadosDemonstracao`: Inclusão de dados de demonstração para utilização e testes da aplicação. 

As finalidades acima foram descritas com base nos nomes das migrations. As alterações detalhadas de cada uma podem ser consultadas nos arquivos correspondentes do projeto.

A execução das migrations durante a configuração inicial do ambiente será apresentada no guia de instalação deste README.

### 6.3 Dados Iniciais

A aplicação possui dados estruturais e dados de demonstração preparados por meio de migrations.

Entre os dados estruturais, estão os quatro perfis de acesso:

 1 - Sistema 
 2 - Administrador 
 3 - Funcionário 
 4 - Cliente 

O perfil `Sistema` é destinado à identificação de operações automáticas executadas pela própria aplicação.

Os demais perfis representam os principais tipos de usuários que utilizam o sistema.

O projeto também possui migrations destinadas à inclusão de dados iniciais e de demonstração, utilizados para apoiar a execução da API e a reprodução dos cenários de teste durante a fase de desenvolvimento.
Todavia, os dados de demonstração são os destinados para teste da API.

As instruções para configurar o banco de dados, aplicar as migrations e executar os testes serão detalhadas nas próximas seções.



## 7. Perfis de Acesso e Autenticação

A API possui controle de acesso de usuários e perfis para execução da maior parte de suas requisições. A seguir são apresentadas as informações relacionadas às decisões tomadas e funcionamento dos 
processos:

### 7.1 Autenticação

Para efetuar o login, o usuário deve informar seu endereço de e-mail e sua senha. Essa senha é armazenada no banco em formato hash através da ferramenta PasswordHasher do ASP.NET Core. A mesma ferramenta
é responsável por fazer a validação da senha em cada login. Após validação das credenciais, o sistema gera um token JWT com validade de 60 minutos. Esse token deve ser enviado nas requisições protegidas 
por meio do cabeçalho `Authorization: Bearer <token>`. O JWT contém informações de identificação e autorização do usuário, enquanto a API verifica essas informações e aplica as regras de acesso.

### 7.2 Perfis de Acesso

Existem 4 perfis de acesso para a API:

- Sistema: Identificação de operações automáticas executadas somente pela aplicação. Perfil inacessível a qualquer usuário.
- Admin: Permissão para realizar gerenciamento de funcionários e consultas administrativas, incluindo pedidos, usuários, auditorias e consentimentos.
- Funcionário: Permissão de criação e acompanhamento de pedidos, restrito à unidade à qual está vinculado.
- Cliente: Permissão para cadastro, realização e consulta dos próprios pedidos, além do gerenciamento de seus consentimentos.

As operações não se restringem somente ao perfil de acesso de um usuário, mas também à relação do usuário com o recurso. Por exemplo: um cliente não pode consultar o pedido de outro cliente, mesmo que 
ambos possuam o mesmo perfil. Assim como um funcionário não pode consultar ou alterar pedidos de uma unidade à qual não pertence.

### 7.3 Segurança e Controle de Acesso

Os endpoints da API são protegidos por mecanismos específicos para que as operações sejam realizadas apenas por usuários autenticados e autorizados. Os mecanismos são:

- JWT Bearer: Responsável por identificar o usuário autenticado nas requisições protegidas;
- Autorização por perfis: Responsável por restringir funcionalidades conforme as permissões do usuário;
- Validação de propriedade e unidade: Responsável por impedir o acesso a recursos de outros clientes ou de unidades não autorizadas;
- Hash de senhas: Utilizado para evitar o armazenamento de senhas em texto puro;
- User Secrets: Utilizado para manter configurações sensíveis, como a chave JWT e a conexão com o banco, fora dos arquivos versionados durante o desenvolvimento.


As consultas públicas de unidades e seus respectivos cardápios não exigem autenticação, conforme a definição adotada durante o desenvolvimento da API.



## 8. Guia de Instalação, Configuração e Testes

Este guia descreve o processo de instalação, configuração, execução e validação da API Rede Raízes do Nordeste em um ambiente Windows.

O procedimento foi validado em dois computadores diferentes daquele utilizado originalmente no desenvolvimento, desde a clonagem do repositório até a execução dos testes automatizados.

### 8.1. Informações Importantes Antes da Instalação

#### 8.1.1. Compatibilidade com o Smart App Control do Windows 11

Durante o primeiro teste de reprodução, foi identificado que o recurso **Smart App Control (Controle Inteligente de Aplicativos)** do Windows 11 bloqueou bibliotecas compiladas localmente, impedindo a
execução da API e das migrations.

O erro apresentado foi:

```
System.IO.FileLoadException:
Uma política de Controle de Aplicativo bloqueou este arquivo.
(0x800711C7)
```

O arquivo bloqueado foi `RaizesNordeste.Infrastructure.dll`.

No ambiente em que esse problema ocorreu, a desativação do Smart App Control permitiu que as migrations e a API fossem executadas normalmente. No segundo teste, o recurso já estava desativado e não houve
esse bloqueio.

**Recomendação para ambientes de avaliação:** antes de iniciar a instalação, verifique se o Smart App Control está ativado. Caso o computador seja destinado a testes de desenvolvimento e apresente esse 
bloqueio, é aconselhável que o usuário desative essa opção para evitar o bloqueio identificado durante o primeiro teste.

Para consultar a configuração:

1. Abra o menu **Iniciar** do Windows.
2. Pesquise por **Segurança do Windows**.
3. Acesse **Controle de aplicativos e navegador**.
4. Selecione **Configurações do Controle Inteligente de Aplicativos**.
5. Verifique o estado do recurso.

Não é necessário desativar o Microsoft Defender, o firewall ou outras proteções do sistema para seguir este guia.

#### 8.1.2. Ferramentas Administrativas do PostgreSQL

O **SQL Shell (psql)** e o **pgAdmin 4** são ferramentas opcionais.

Nos testes de reprodução, não foi necessário utilizá-los para preparar o banco de dados. Os comandos de configuração foram executados pelo Windows PowerShell.

O Entity Framework Core realizou a criação do banco de dados e a aplicação das migrations diretamente.

Portanto, não é necessário abrir o pgAdmin ou executar comandos SQL manualmente para preparar a aplicação.

#### 8.1.3. Requisitos de Software

Para reproduzir o projeto, são necessários:

- Windows 10 ou Windows 11;
- Git para Windows;
- .NET SDK 10;
- PostgreSQL 18;
- Postman;
- Conexão com a internet para instalação das ferramentas e restauração das dependências.

O Visual Studio não é obrigatório para executar a API. Os procedimentos podem ser realizados diretamente pelo Windows PowerShell. O Visual Studio é aconselhado para visualização do código, devido ao
fato de ser a IDE utilizada para o desenvolvimento da solução.

### 8.2. Instalação das Ferramentas

#### 8.2.1. Instalar o Git

Acesse:

https://git-scm.com/downloads/win

Baixe e instale a versão adequada para Windows.

#### 8.2.2. Instalar o .NET SDK 10

Acesse:

https://dotnet.microsoft.com/download/dotnet/10.0

Baixe e instale o SDK 10.

Após a instalação, abra o PowerShell e execute:

```powershell
dotnet --version
```

O resultado deverá indicar uma versão iniciada por `10.`.

#### 8.2.3. Instalar o PostgreSQL 18

Acesse:

https://www.postgresql.org/download/windows/

Durante a instalação:

1. Selecione os componentes necessários para o PostgreSQL Server.
2. Defina uma senha para o usuário administrador `postgres`.
3. Mantenha a porta padrão `5432`.
4. Mantenha a configuração de localidade `Default`.
5. Conclua a instalação.

Guarde a senha definida, pois ela será utilizada posteriormente na configuração da API.

**Verificar o serviço**

Abra o PowerShell e execute:

```powershell
Get-Service postgresql*
```

O resultado esperado será semelhante a:

```
Status   Name
------   ----
Running  postgresql-x64-18
```

**Verificar a conectividade**

Execute:

```powershell
Test-NetConnection localhost -Port 5432
```

O resultado esperado é:

```
TcpTestSucceeded : True
```

Esse teste confirma que a porta está acessível, mas não valida a senha do banco de dados.

#### 8.2.4. Instalar o Postman

Acesse:

https://www.postman.com/downloads/

Baixe e instale o aplicativo Postman para Windows.

### 8.3. Clonagem do Repositório

Abra o PowerShell na pasta onde o projeto será clonado.

Execute:

```powershell
git clone https://github.com/MauBeleg/RedeRaizesNordeste.git
```

Entre na pasta do projeto:

```powershell
cd .\RedeRaizesNordeste
```

Verifique o estado do repositório:

```powershell
git status
```

O comando deverá indicar a branch atual e, em uma clonagem recém-concluída, a ausência de alterações locais.

**Importante:** os próximos comandos devem ser executados na pasta principal `RedeRaizesNordeste`, salvo quando indicado de outra forma.

### 8.4. Restauração e Compilação

Restaure as dependências:

```powershell
dotnet restore
```

Em seguida, compile o projeto:

```powershell
dotnet build
```

O resultado esperado é uma compilação concluída sem erros.

A solução é organizada em quatro projetos:

- `RaizesNordeste.Api`: camada de apresentação HTTP e configuração da API.
- `RaizesNordeste.Application`: regras e serviços de aplicação.
- `RaizesNordeste.Domain`: entidades e elementos do domínio.
- `RaizesNordeste.Infrastructure`: persistência de dados e integração com PostgreSQL.

### 8.5. Configuração do Banco de Dados

A aplicação utiliza o mecanismo **User Secrets** do .NET para armazenar configurações locais sensíveis.

Isso evita que a senha do banco de dados e a chave JWT sejam incluídas diretamente nos arquivos de configuração versionados no GitHub.

#### 8.5.1. Configurar a Conexão com o PostgreSQL

Na pasta principal do repositório, execute:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=raizes_nordeste;Username=postgres;Password=SUA_SENHA_AQUI" --project .\src\RaizesNordeste.Api
```

Substitua `SUA_SENHA_AQUI` pela senha definida durante a instalação do PostgreSQL.

A configuração utiliza:

| Propriedade | Valor |
|---|---|
| Host | `localhost` |
| Porta | `5432` |
| Banco de dados | `raizes_nordeste` |
| Usuário | `postgres` |
| Senha | Definida durante a instalação |

#### 8.5.2. Configurar a Chave de Autenticação JWT

A API utiliza JWT para autenticação e autorização.

Para gerar uma chave criptograficamente segura, execute os seguintes comandos no PowerShell:

```powershell
$bytes = New-Object byte[] 64

$rng = [System.Security.Cryptography.RandomNumberGenerator]::Create()

$rng.GetBytes($bytes)

$jwtKey = [Convert]::ToBase64String($bytes)

dotnet user-secrets set "Jwt:Chave" $jwtKey --project .\src\RaizesNordeste.Api

$rng.Dispose()

Remove-Variable bytes, rng, jwtKey
```

O procedimento gera 64 bytes aleatórios e é compatível com o Windows PowerShell 5.1.

**Importante:** o nome correto da configuração utilizado pela API é `Jwt:Chave`, e não `Jwt:Key`.

#### 8.5.3. Confirmar as Configurações

Execute:

```powershell
dotnet user-secrets list --project .\src\RaizesNordeste.Api |
    ForEach-Object { ($_ -split ' = ', 2)[0] }
```

As configurações esperadas são:

```
ConnectionStrings:DefaultConnection
Jwt:Chave
```

A ordem de apresentação pode variar.

Esse comando mostra apenas os nomes das configurações, evitando exibir os valores secretos.

### 8.6. Configuração do Entity Framework Core

#### 8.6.1. Restaurar a Ferramenta de Migrations

Execute:

```powershell
dotnet tool restore
```

Depois, confirme a instalação:

```powershell
dotnet ef --version
```

O comando deverá apresentar a versão instalada da ferramenta Entity Framework Core.

#### 8.6.2. Criar o Banco e Aplicar as Migrations

Execute:

```powershell
dotnet ef database update --project .\src\RaizesNordeste.Infrastructure --startup-project .\src\RaizesNordeste.Api
```

Esse comando utiliza a conexão configurada nos User Secrets para:

1. Conectar ao PostgreSQL.
2. Criar o banco `raizes_nordeste`, caso ele não exista e o usuário tenha permissão.
3. Criar as tabelas e seus relacionamentos.
4. Aplicar as migrations existentes.
5. Inserir os dados iniciais e demonstrativos definidos nas migrations do projeto.

Ao final, o terminal deverá apresentar uma mensagem semelhante a:

```
Done.
```

Não é necessário criar o banco manualmente pelo pgAdmin.

### 8.7. Configuração do Certificado HTTPS

Antes de iniciar a API, execute:

```powershell
dotnet dev-certs https --trust
```

O Windows poderá solicitar confirmação para confiar no certificado de desenvolvimento.

Confirme a solicitação.

O resultado esperado é semelhante a:

```
Successfully trusted the existing HTTPS certificate.
```

Esse certificado é utilizado apenas no ambiente local de desenvolvimento.

### 8.8. Inicialização da API

Na pasta principal do projeto, execute:

```powershell
dotnet run --project .\src\RaizesNordeste.Api --launch-profile https
```

A aplicação deverá apresentar mensagens semelhantes a:

```
Now listening on: https://localhost:7111
Now listening on: http://localhost:5216
Application started.
Hosting environment: Development
```

A API estará disponível em:

https://localhost:7111

**Importante:** mantenha o PowerShell aberto enquanto estiver utilizando o Swagger ou executando os testes no Postman.

### 8.9. Validação pelo Swagger

Com a API em execução, abra o navegador e acesse:

https://localhost:7111/swagger

A interface Swagger UI deverá apresentar a documentação da API e seus endpoints.

Entre os recursos disponíveis estão autenticação, usuários, unidades, produtos, cardápios, pedidos, pagamentos simulados, auditoria e consentimentos, conforme as operações implementadas no projeto.

O Swagger permite consultar os endpoints e realizar requisições HTTP diretamente pelo navegador.

### 8.10. Execução dos Testes Automatizados no Postman

#### 8.10.1. Importar a Coleção

Abra o Postman e selecione **Import**.

Escolha o arquivo:

```
postman/Rede Raízes do Nordeste API.postman_collection.json
```

Esse arquivo está disponível no repositório, dentro da pasta `postman`.

#### 8.10.2. Verificar as Variáveis da Coleção

Abra as configurações da coleção e localize a seção **Variables**.

Confirme que a variável `baseUrl` contém:

```
https://localhost:7111
```

Além disso, as variáveis `unidadeId` e `produtoId` devem conter o valor `1`, conforme os dados de demonstração utilizados nos testes.

A coleção utiliza variáveis para armazenar informações necessárias durante a execução, incluindo tokens de autenticação e identificadores de registros.

Não é necessário selecionar um ambiente externo do Postman quando as variáveis necessárias já estão configuradas na própria coleção.

#### 8.10.3. Executar os Testes

1. Localize a coleção **Rede Raízes do Nordeste API**.
2. Selecione a pasta **09 — Cenários de Teste**.
3. Abra a opção **Run** dessa pasta.
4. Mantenha uma iteração.
5. Execute todos os testes da pasta 09.
6. Aguarde a apresentação do relatório de resultados.

A pasta 09 contém o fluxo organizado de cenários de teste automatizado, incluindo casos positivos e negativos, e possui todos os requisitos de testes obrigatórios do FLUXO A.

As pastas 01 a 08 possuem outras requisições da API, organizadas por funcionalidades, que podem ser executadas individualmente.

É possível realizar todo o fluxo de criação do pedido até sua entrega.
Basta seguir o seguinte fluxo: Realizar todos os logins da pasta 01 - Autenticação; Consultar Cardápio da Unidade na pasta 02 - Unidades e Cardápio; Criar Pedido (Cliente) na pasta 03 - Pedidos;
Acionar os três endpoints da pasta 04 - Pagamentos; Retornar à pasta 03 - Pedidos e acionar os três endpoints de mudança de status do pedido; É possível consultar esse mesmo pedido como Cliente na
mesma pasta; E por fim é possível verificar todo o histórico do pedido como Admin acionando o endpoint Listar Auditorias (Admin), da pasta 06 - Auditorias, ativando o parâmetro registroId, que será 
atribuido valor automaticamente durante o procedimento deste fluxo.

A consulta obrigatória de pedidos por CanalPedido e Status pode ser feita pelo endpoint Listar Pedidos (Admin) da pasta 03 - Pedidos, ativando os parâmetros canalPedido e status.

Valores possíveis para canalPedido: App, Web, Totem, Balcao, Pickup    OBS: A seed de dados de demonstração possui 7 pedidos, e possui somente pedidos feitos via App e Web. É necessário criar um novo
pedido com outro canal para testar as demais opções)

Valores possíveis para status: AguardandoPagamento, Recebido, EmPreparo, Pronto, Entregue

**Importante:** a API deve permanecer em execução durante todo o procedimento.

#### 8.10.4. Resultados das Reproduções

Nas reproduções realizadas com a versão da coleção utilizada naquela etapa do desenvolvimento, mais especificamente os testes automatizados da pasta 09, o Postman apresentou:

| Indicador | Resultado |
|---|---|
| Asserções executadas | 50 |
| Falhas | 0 |
| Iterações | 1 |
| Duração | Aproximadamente 12 segundos |

Os testes contemplaram cenários funcionais e de validação da API, incluindo autenticação, permissões, consultas, pedidos e pagamentos simulados.

**Observação:** esses números representam os resultados obtidos nas reproduções anteriores. A quantidade de asserções e a duração podem variar conforme alterações posteriores na coleção ou no estado do 
banco de dados.

### 8.11. Solução de Problemas

#### 8.11.1. Smart App Control Bloqueando a API

**Sintoma:** a aplicação compila, mas sua execução ou a aplicação das migrations apresenta o erro `0x800711C7`.

**Procedimento:**

Consulte a seção 8.1.1 e verifique se o bloqueio está relacionado ao Smart App Control.

Antes de alterar as proteções do Windows, avalie as opções permitidas pela política de segurança do computador.

Após resolver o bloqueio, execute novamente:

```powershell
dotnet ef database update --project .\src\RaizesNordeste.Infrastructure --startup-project .\src\RaizesNordeste.Api
```

Em seguida:

```powershell
dotnet run --project .\src\RaizesNordeste.Api --launch-profile https
```

#### 8.11.2. Falha de Conexão com o PostgreSQL

**Sintoma:** o Entity Framework Core ou a API informa que não consegue conectar ao banco de dados.

**Passo 1 — Verificar o serviço**

```powershell
Get-Service postgresql*
```

Se o serviço estiver parado, abra o PowerShell como administrador e execute:

```powershell
Start-Service postgresql-x64-18
```

Caso o nome do serviço seja diferente, utilize o nome apresentado na consulta anterior.

**Passo 2 — Verificar a porta**

```powershell
Test-NetConnection localhost -Port 5432
```

O resultado esperado é:

```
TcpTestSucceeded : True
```

Se a porta estiver inacessível, verifique a instalação e a configuração do PostgreSQL.

**Passo 3 — Corrigir a conexão**

Se o serviço estiver ativo, mas houver erro de autenticação, configure novamente os User Secrets com a senha correta:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=raizes_nordeste;Username=postgres;Password=SUA_SENHA_AQUI" --project .\src\RaizesNordeste.Api
```

Substitua `SUA_SENHA_AQUI` pela senha do PostgreSQL.

**Passo 4 — Repetir as migrations**

```powershell
dotnet ef database update --project .\src\RaizesNordeste.Infrastructure --startup-project .\src\RaizesNordeste.Api
```

A execução bem-sucedida deverá terminar com uma mensagem semelhante a `Done.`.

#### 8.11.3. Certificado HTTPS Não Confiável

**Sintoma:** o navegador apresenta um aviso de certificado ou a API informa:

```
The ASP.NET Core developer certificate is not trusted.
```

**Solução:**

Abra um novo PowerShell e execute:

```powershell
dotnet dev-certs https --trust
```

Confirme a solicitação do Windows.

Se o problema persistir, interrompa a API com `Ctrl+C`, execute-a novamente e tente acessar:

https://localhost:7111/swagger

#### 8.11.4. Comando dotnet ef Não Encontrado

**Sintoma:** o PowerShell informa que o comando `dotnet ef` não está disponível.

**Solução:**

Na pasta principal do repositório, execute:

```powershell
dotnet tool restore
```

Depois:

```powershell
dotnet ef --version
```

Se o comando continuar indisponível, confirme a instalação do SDK:

```powershell
dotnet --version
```

O resultado deverá iniciar com `10.`.

Após corrigir o problema, execute novamente:

```powershell
dotnet ef database update --project .\src\RaizesNordeste.Infrastructure --startup-project .\src\RaizesNordeste.Api
```

#### 8.11.5. Swagger Não Abre no Navegador

**Sintoma:** o endereço `https://localhost:7111/swagger` não carrega.

**Solução:**

1. Verifique se a API continua executando no PowerShell.
2. Confirme se o terminal apresenta `Now listening on: https://localhost:7111`.
3. Se a API estiver encerrada, execute:

```powershell
dotnet run --project .\src\RaizesNordeste.Api --launch-profile https
```

4. Aguarde a mensagem `Application started`.
5. Acesse novamente o Swagger.

Caso o terminal apresente uma porta HTTPS diferente, utilize a porta efetivamente indicada.

#### 8.11.6. Erro de Certificado SSL no Postman

**Sintoma:** o Postman não consegue realizar requisições HTTPS para a API local por falha de verificação do certificado.

**Solução:**

1. Confirme que o certificado de desenvolvimento foi configurado com `dotnet dev-certs https --trust`.
2. Verifique se o endereço da coleção corresponde à porta HTTPS da API.
3. Reinicie o Postman, caso ele já estivesse aberto antes da configuração do certificado.
4. Se o Postman continuar rejeitando o certificado, consulte suas configurações de verificação de certificados SSL.

Em um ambiente estritamente local de testes, a verificação de certificados SSL pode ser desativada temporariamente para diagnosticar o problema, devendo ser reativada após a execução.

### 8.12. Evidências de Reprodução

O procedimento foi validado em dois computadores Windows diferentes daquele utilizado originalmente no desenvolvimento, com instalação independente das ferramentas e clonagem do código-fonte diretamente 
do GitHub. Em ambos os computadores o Smart App Control precisou ser destivado para o teste da API. Não se trata de um erro da API ou da modelagem da solução, mas uma limitação do sistema operacional.

As duas reproduções confirmaram:

- Restauração e compilação da aplicação;
- Configuração do PostgreSQL e dos User Secrets;
- Criação do banco de dados e aplicação das migrations;
- Inicialização da API em ambiente de desenvolvimento;
- Acesso à documentação Swagger;
- Execução da coleção de testes automatizados no Postman, com 50 asserções aprovadas e nenhuma falha na versão utilizada durante as reproduções.

Esses resultados demonstram que o projeto pôde ser configurado e executado em ambientes diferentes daquele utilizado originalmente no desenvolvimento.


## 9. Delimitação do Escopo e Limitações da Implementação

O desenvolvimento da API Rede Raízes do Nordeste foi direcionado ao atendimento dos requisitos relacionados ao **Fluxo A**, conforme definido nos documentos de orientação do projeto.

A solução foi estruturada para contemplar as operações de autenticação, consulta de unidades e cardápios, criação de pedidos, validação de disponibilidade de estoque, simulação de pagamentos e acompanhamento do pedido até sua entrega.

Embora a modelagem da aplicação considere possibilidades de expansão, algumas funcionalidades foram mantidas fora do escopo implementado ou desenvolvidas apenas parcialmente.

### 9.1. Fluxo B

O projeto foi desenvolvido com foco no **Fluxo A**, não contemplando a implementação do **Fluxo B** apresentado nos documentos de orientação.

Essa delimitação foi adotada para concentrar o desenvolvimento e os testes nas operações relacionadas ao fluxo de pedidos, pagamentos e acompanhamento de status.

### 9.2. Controle e Movimentação de Estoque

A API realiza a consulta e a validação da disponibilidade dos produtos em estoque durante o processo de criação de pedidos.

A disponibilidade dos itens é utilizada como condição para permitir ou impedir o registro de um pedido, conforme as quantidades necessárias para atender à solicitação.

Entretanto, **não foi implementada a baixa definitiva das quantidades em estoque após a efetivação do pedido**.

Dessa forma, embora a disponibilidade seja considerada durante a validação, a solução ainda não contempla o ciclo completo de movimentação de estoque, incluindo o desconto definitivo dos insumos consumidos.

### 9.3. Campanhas Promocionais e Programa de Fidelização

A aplicação foi modelada considerando a possibilidade de implementação futura de campanhas promocionais e de um programa de fidelização de clientes.

A proposta do programa de fidelização consiste na atribuição de pontos aos clientes, que seriam acumulados e armazenados no sistema. Posteriormente, durante a realização de novos pedidos, esses pontos poderiam ser utilizados para obtenção de descontos, conforme regras de resgate previamente definidas.

Essa proposta motivou a inclusão de estruturas relacionadas ao armazenamento de pontos, ao histórico de movimentações e às regras de resgate no modelo de dados.

Entretanto, **as operações necessárias para atribuição, acumulação e utilização de pontos como descontos não foram implementadas nesta versão da API**.

Da mesma forma, não foi implementado um mecanismo de gerenciamento e aplicação de campanhas promocionais aos pedidos.

### 9.4. Integração com Sistemas Externos de Pagamento

O processamento de pagamentos foi implementado de forma simulada, permitindo representar situações de aprovação e recusa.

Não existe integração com gateways de pagamento, instituições financeiras ou outros serviços externos responsáveis pelo processamento de transações reais.

A simulação foi adotada para permitir a validação das regras de negócio e das transições de status dos pedidos sem depender de serviços externos.

### 9.5. Interface de Usuário

A entrega contempla exclusivamente o desenvolvimento do back-end, disponibilizado por meio de uma API REST.

Não foi desenvolvida uma interface front-end destinada à utilização direta por clientes, funcionários ou administradores.

As funcionalidades podem ser consultadas e testadas por meio do Swagger e da coleção de requisições disponibilizada para o Postman.

As limitações apresentadas nesta seção representam decisões de escopo adotadas durante o desenvolvimento e indicam possibilidades de evolução futura da solução.












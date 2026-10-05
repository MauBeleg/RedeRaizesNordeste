# Segurança, LGPD e Auditoria de Dados da API

Este documento tem como objetivo descrever as medidas de segurança, proteção de dados e rastreabilidade adotadas no desenvolvimento do Projeto Rede Raízes do Nordeste.



## 1. Finalidade e minimização dos dados

Os dados tratados pela API são utilizados de acordo com as necessidades das funcionalidades do sistema. Informações dos usuários, como senha e e-mail, são utilizadas para identificação, 
autenticação e controle de acesso, enquanto os dados relacionados aos pedidos são utilizados para identificar o cliente, produtos que constam no pedido e valores da operação
de modo a permitir o processamento das operações realizadas na plataforma. O acesso aos dados e funcionalidades da API é definido de acordo com o ROLE do usuário (Cliente, Admin e 
Funcionário), garantindo que cada perfil tenha acesso somente a informações e operações relevantes às suas permissões e papéis na solução.

Durante o desenvolvimento buscou-se limitar o tratamento e a exposição das informações ao necessário para cada funcionalidade. Os endpoints retornam apenas os dados relevantes para a 
operação solicitada, evitando expor informações internas ou dados pessoais desnecessários relacionados tanto ao usuário quanto às regras de negócio quando estas não se fazem necessárias. 
A consulta de auditoria, por exemplo, identifica o usuário responsável pela operação através de seu identificador e nome, sem retornar informações como credenciais, hash de senha ou token 
de autenticação.

### 1.1 Bases legais consideradas

O tratamento dos dados pessoais realizado pela aplicação considera a finalidade associada a cada operação, e o consentimento não é utilizado como justificativa para todo tratamento 
realizado pelo sistema.

Os dados utilizados para identificação e cadastro do cliente, como nome, e-mail, CPF e data de nascimento, assim como as informações necessárias para criação e processamento de pedidos,
dizem respeito a interação entre cliente e sistema, e se aplica a operações realizadas pelo próprio cliente. Para essas operações, foi considerada na modelagem a base legal relacionada 
à execução de contrato ou de procedimentos preliminares relacionados à relação contratual.


Para funcionalidades de fidelização e campanhas, foi adotado o consentimento como base para o tratamento relacionado especificamente a essas finalidades. O cliente pode aceitar ou 
recusar esse tratamento, sendo cada manifestação registrada pelo sistema para permitir sua consulta e rastreabilidade posteriormente.


Os registros de auditoria possuem finalidade de segurança e rastreabilidade das operações realizadas na aplicação. Para esse tratamento, foi considerada na modelagem a hipótese de 
legítimo interesse, quando aplicável, considerando a necessidade de segurança e rastreabilidade das operações. O projeto considera apenas operações críticas, 
limitando os registros às informações necessárias para identificar a operação e seu responsável e restringindo sua consulta a usuários autorizados.


Determinadas informações também poderão necessitar de conservação em razão de obrigações legais ou regulatórias aplicáveis a essas operações. Dessa forma, a retirada de um consentimento 
relacionado a campanhas ou fidelização não implica em exclusão de todos os dados do cliente automaticamente, uma vez que outros tratamentos podem possuir finalidades e bases legais 
distintas que justifiquem a manutenção de determinadas informações.


As bases legais apresentadas foram consideradas para fins de modelagem acadêmica do MVP e não representam uma análise jurídica definitiva sobre uma eventual utilização comercial da 
solução.

## 2. Proteção de credenciais

As senhas utilizadas pelos usuários da aplicação não são armazenadas diretamente em texto puro: durante o cadastro, a aplicação utiliza o PasswordHasher disponibilizado pelo ASP.NET Core 
Identity para gerar um hash da senha, que é então armazenado junto aos dados do usuário no banco.

Durante o processo de autenticação, a senha informada pelo usuário é verificada através do próprio PasswordHasher, que a compara com o hash previamente armazenado. A aplicação somente 
prossegue com a autenticação e geração do token quando a verificação da senha é bem-sucedida e o usuário está ativo.

A responsabilidade pela geração e verificação dos hashes é feita através da interface ISenhaHasher, evitando que os serviços responsáveis pelas regras da aplicação dependam diretamente 
da implementação utilizada para proteção das senhas.

## 3. Autenticação e autorização

A autenticação da API é realizada através de tokens JWT. Durante o login, a aplicação verifica a existência do usuário, se ele está ativo e valida a senha informada em relação ao hash 
armazenado. Quando as informações são válidas, é gerado um token contendo informações necessárias para identificação e autorização do usuário, tais como seu identificador, e-mail, 
perfil e ROLE.

Os tokens possuem emissor, destinatário e tempo de expiração de 1 (uma) hora, todos definidos nas configurações da aplicação. São assinados utilizando o algoritmo HMAC-SHA256 e uma 
chave configurada no ambiente da API. As requisições a recursos protegidos devem apresentar o token de autenticação válido, permitindo que a aplicação identifique o usuário responsável 
pela requisição.

A autorização é realizada de acordo com a ROLE associada ao usuário. Os perfis CLIENTE, FUNCIONARIO, ADMIN e SISTEMA possuem diferentes permissões de acesso às funcionalidades da API. 
Dessa forma, estar autenticado não garante acesso irrestrito aos recursos: cada endpoint protegido verifica as permissões necessárias para a operação solicitada. A consulta de auditorias,
por exemplo, é restrita ao perfil ADMIN, enquanto operações relacionadas aos pedidos também consideram o perfil do usuário e sua relação com o recurso acessado.

## 4. Auditoria e rastreabilidade

A modelagem para auditoria e rastreabilidade de operações foi pensada de forma a permitir o registro das principais informações relacionadas à utilização da solução e também o acesso a 
esses dados por usuários autorizados.

Para o escopo do MVP, foram definidos três eventos para registro de auditoria: Criação de Pedido, Processamento de Pagamento e Alteração de Status do Pedido. Os dados registrados para 
auditoria representam a identificação do registro de auditoria, o usuário responsável pela operação, a ação realizada, a entidade à qual diz respeito à operação, a identificação do registro
dessa entidade, detalhes opcionais para descrever o evento e, por fim, a data de criação do registro.

Através do endpoint `GET /api/auditorias`, um usuário com ROLE = ADMIN poderá acessar essas informações, aplicando filtros como: usuário que realizou a ação, tipo de evento, tipo de 
entidade alvo do evento ou o próprio registro dessa entidade. Dessa forma, é possível localizar os dados esperados e, inclusive, acompanhar as operações realizadas desde a criação de um 
pedido até sua entrega.

## 5. Consentimento

O sistema possui registro de consentimento para finalidades relacionadas à fidelização e campanhas. Embora não haja implementação de métodos para geração de campanhas de promoções ou registro
de clientes nos planos de fidelidade, a arquitetura foi desenvolvida considerando uma futura implementação dessas funcionalidades. O consentimento é destinado unicamente a usuários do 
ROLE "CLIENTE", que podem aceitar ou recusar os termos através do endpoint `POST /api/consentimentos`.

Cada manifestação de um cliente, tanto positiva quanto negativa, gera um novo registro na tabela de Consentimento, podendo ser consultadas pelo próprio cliente, ou usuário com ROLE "ADMIN"
para finalidades administrativas.

O usuário com ROLE "ADMIN" possui apenas acesso de consulta aos registros de consentimento, não podendo registrar uma manifestação em nome do cliente.

O consentimento não diz respeito à toda a base de tratamento do sistema, apenas para as finalidades citadas acima. Informações de CPF, data de nascimento, email e senha não são regitsradas nos
termos de consentimento, de modo a preservar a privacidade dos dados.

CPF e data de nascimento foram adicionados ao cadastro de cliente como dados pessoais utilizados para identificação do usuário. O CPF é normalizado antes do armazenamento e possui restrição 
de unicidade. Esses dados não são retornados pelas consultas gerais de usuários, reduzindo sua exposição desnecessária

## 6. Anonimização e retenção

No momento, o MVP do projeto não possui mecanismos automáticos para anonimização ou exclusão de dados pessoais após determinado período de tempo. Entretanto, foram adotadas medidas para 
limitar a exposição de dados que não sejam necessários às operações realizadas pela API. A aplicação também permite definir um usuário como inativo, impedindo sua autenticação enquanto 
permanecer nessa condição. Em uma eventual utilização da solução em ambiente de produção, seria necessário definir políticas de retenção determinando por quanto tempo os diferentes dados 
devem ser mantidos e procedimentos para sua exclusão ou anonimização quando aplicáveis e quando sua manutenção deixar de ser necessária.

## 7. Pagamento mock e proteção de dados

O pagamento MOCK implementado foi pensado no âmbito acadêmico, não processando transações financeiras reais nem realizando coleta de dados financeiros, como número de cartão ou outras 
informações relacionadas a meios reais de pagamento. O sistema utiliza apenas as informações necessárias para simular o processamento de um pagamento e definir se a operação deve ser aceita 
ou recusada, permitindo demonstrar o fluxo completo desde a criação do pedido até a alteração de seu status após o processamento do pagamento.

## 8. Limitações do MVP

A Auditoria não cobre todas as ações possíveis dentro da aplicação, somente a criação de pedidos, a mudança de seus status e a realização ou tentativa de pagamentos.

O registro dos dados de auditoria não ocorre na mesma gravação das operações principais, sendo realizado em uma operação separada. Dessa forma, no escopo atual do MVP, existe a 
possibilidade de a operação principal ser persistida e ocorrer uma falha posterior durante o registro da auditoria. Uma implementação destinada à produção poderia adotar mecanismos 
transacionais ou outras estratégias para aumentar a consistência entre essas operações.

O MVP não possui mecanismos automáticos de anonimização, exclusão ou políticas automatizadas de retenção de dados.

Os tipos de consentimento implementados estão limitados às finalidades de fidelização e campanhas.

A validação de CPF implementada no MVP é estrutural, verificando a existência de 11 dígitos numéricos após sua normalização. Não foi implementada a validação dos dígitos verificadores 
do CPF, pois esse nível de validação foi considerado fora do escopo necessário para os testes acadêmicos da solução.

As medidas implementadas foram desenvolvidas considerando os requisitos e princípios apresentados nos documentos do projeto, juntamente com decisões de modelagem e arquitetura adotadas 
durante o desenvolvimento do MVP. Essas medidas buscam reduzir a exposição desnecessária de dados e estabelecer mecanismos básicos de segurança, autorização e rastreabilidade, sem 
representar uma garantia de conformidade jurídica integral da solução com a LGPD.
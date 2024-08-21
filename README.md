# Teste OPAH
## Introdução

Um comerciante precisa controlar o seu fluxo de caixa diário com os lançamentos (débitos e
créditos), também precisa de um relatório que disponibilize o saldo diário consolidado.

Foram criados 2 microsserviços:

* Serviço de controle de lançamentos
* Serviço do consolidado diário

## Pre-requisitos

Para que os microsserviço funcionem, é necessário configurar as seguintes variáveis de ambiente (ou arquivo appsettings.json):  
* ASPNETCORE_ENVIRONMENT  
Development, Release ou Production, indica o ambiente de deploy
* SERVICE_NAME  
Nome do serviço: Nome do microsserviço: Opah.Lancamento.Microsserviço
* SERVICE_DESCRIPTION  
Descrição do serviço -> Descrição do microsserviço: Microsserviço de teste
* SERVICE_VERSION  
Versão do serviço -> ex: 1.0.0
* Opah.Lancamento-MaxMemory  
Quantidade em bytes de memória que se excedida deve reiniciar o container (microsserviço de lancamentos)
* Opah.Consolidado-MaxMemory  
Quantidade em bytes de memória que se excedida deve reiniciar o container (microsserviço de consolidado)
* log-path  
Configuraçao do log - caminho do log
* mongo-connection  
Connection string do mongo db no formato: mongodb://user:password@server:port
* mongo-database  
Nome do banco de dados do mongo db

## Correlation ID
O correlation id é usado para rastrear por um mesmo id todas as chamadas de microsservicos correlacionados. Qualquer gravaçao de dados no log utilizará o mesmo id de correlaçao.  
Caso seja passado um id de correlaçao no header como "x-correlation-id", ele será usado no microsserviço e nos microsserviços subsequentes. Caso não seja passado nada, um id será gerado.
Com esse id será possivel rastrear no log tudo que foi gravado relacionado a um request  
Usando "internal-api-request" o id de correlaçao será propagado para os microsserviços subsequentes automaticamente

## Execução do projeto
Apos configurar as variaveis de ambiente (ou arquivo appsettings.json), execute os seguintes comandos dentro da pasta do projeto:

* dotnet restore
* dotnet build
* dotnet run --project .\Opah.Lancamento.API\ --urls=http://localhost:8080/
* dotnet run --project .\Opah.Consolidado.API\ --urls=http://localhost:8081/

O projeto Lancamento estara disponivel para acesso no endereco: http://localhost:8080  
O projeto Consolidado estara disponivel para acesso no endereco: http://localhost:8081  
O swagger do projeto lancamento estara no endereço: http://localhost:8080/swagger/index.html  
O swagger do projeto consolidado estara no endereço: http://localhost:8081/swagger/index.html  

Para rodar o projeto será necessario uma instancia do MongoDB que pode ser disponibilizada via docker:  

* docker run --name mongodb -p 27017:27017 -d mongodb/mongodb-community-server:latest

## Endpoints
O projeto é composto pelos seguintes endpoints:

* [GET] /healthcheck  
Endpoint para healthcheck

* [GET] /  
Endereço base que responde com informaçoes uteis sobre a aplicaçao: nome, versão, ambiente, e id

* [GET] /consolidado
Buscar uma lista consolidada com os lancamentos de debitos e creditos e o saldo atualizado  

* [POST] /debito  
Cadastrar um debito e atualizar o saldo

* [POST] /credito  
Cadastrar um credito e atualizar o saldo

## Dependencias
Esse projeto tem 3 dependências de libs que não foram criadas no nuget por se tratar de um teste:

* Opah.Lancamento.Exemplo.Lib.MicroserviceBase  
Biblioteca de classes base para os microsseviços
* Opah.Lancamento.Exemplo.Lib.Logger  
Biblioteca de logs. Já esta pre programada pra gravar os logs em uma pasta. A ideal em um projeto real seria capturar esses logs e enviar para um servidor como o ELK por exemplo
* Opah.Lancamento.Exemplo.Lib.HttpBase  
Biblioteca com classes base para requests e response e filtro para captura de exceptions automaticamente
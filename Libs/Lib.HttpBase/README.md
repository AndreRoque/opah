# Biblioteca HTTPBase
## Introdução

Essa biblioteca tem como objetivo ser uma base para responses nas apis. Ela padroniza a resposta de erro e sucesso, e deve ser usada como base para quaisquer outras respostas que forem necessarias em uma API. Alem disso ela tem um filtro para ser usado para capturar as exceptions não tratadas e responder adequadamente, inclusive gravando os erros no log.

## Pre-requisitos

Essa biblioteca não tem pre-requisitos

## Execução do projeto
Por se tratar de uma biblioteca, para ser usada, ela deve ser preferencialmente publicada no nuget da Energisa.  

## Dependencias
Esse projeto tem 1 dependência de lib que está no nuget da Energisa e deve ser referenciada nesse projeto:

* Energisa.Exemplo.Lib.Logger  
Biblioteca de logs. Já esta pre programada pra gravar os logs na infra correta.

## Licença
[Energisa](https://www.energisa.com.br/)
<img align="left" width="100" height="100" src="https://media.giphy.com/media/Ie2Hs3A0uJRtK/giphy.gif">

# Backend Challenge
</br></br>
Um desafio técnico para aprofundar e demonstrar conhecimento sobre APIs e sistemas backand
</br></br>
[![.NET](https://github.com/pflausino/backend-challenge/actions/workflows/dotnet.yml/badge.svg)](https://github.com/pflausino/backend-challenge/actions/workflows/dotnet.yml)
[![Node.js CI](https://github.com/pflausino/backend-challenge/actions/workflows/node.js.yml/badge.svg)](https://github.com/pflausino/backend-challenge/actions/workflows/node.js.yml)

## Visão Geral
Essa Repositório contém **2** projetos sendo:
- API1 - Calcula a média do preço do metro quadrado em determinada cidade de acordo com os imoveis disponiveis.
- API2 - Calcula um orçamento de gasto de acordo com a quantidade de metros quadrados em determinada cidade

A maior parte da implementação e das regras de negocio estão na API1 escrita em **.NET5** no entanto, a o endpoit de proposito final está na API2 escrita em **NODE JS**

Fiz dessa maneira afim de demonstrar a aptião em cada uma das stacks sendo a de .NET mais recorrente no meu dia a dia atual 

## Estrutura

Em termos de infraestrutura de deploy esta sendo demonstrado 2 fluxos sendo: O a API1 containerizado e o da API2 em heroku vm
<p align="center">
<img align="center" width="700" height="500" src="https://drive.google.com/uc?id=1_BTT1JOaivqhX30LYbayeXbzZPA4GPSJ">>
</p>

Perceba que independente independente da estrutura em deploy, quando estamos em dev com máquinas locais, usamos o docker composer para facilidar e execução em diferentes ambientes

## Tecnologias e conceitos de desenvolvimento

Vamos começar pela **.NET (API1)**
<br>
<img align="left" width="100" height="100" src="https://64.media.tumblr.com/tumblr_mcojibRSRa1qhjy9xo1_400.gifv">

Desenvolvida com .NET5 Composta pro 3 projetos de implementaçao e dois projetos de teste, a Sln está na raiz do projeto
<br>
<br><br>
Foram usados os Patterns: 
- Notification Pattern (com fluent validation)
- CQRS - Command Query Responsability Segregation
- Mediatr
- Unit Of Work
- Repository Pattern
- Dependency Injection

Foram usados Value Objects para evitar Primitive Obsession, Teste Unitarios foram desenvolvidos para Controllers mas Principalmente para o Dominio

Para testes foi usado o Framework XUnit com as libs AutoFixture, Moq e Auto.Moq

O Swagger foi configurado (que agora já vem por padrão no .NET5)

<br>
<img align="right" width="100" height="100" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTeesAE9ObgeJZMBxgg4gccnHoB4EQlwtIgy-ZLIatNOxfKAOPrdI0m8MSRo0UVQZsjKLo&usqp=CAU">


Agora Node **(API2)**

Bem mais simples, essa api em Javascript usa o pacote Express JS como base, Axios foi o client http usado para se comunicar com a API1. Ela se encontra sob o diretório 
```
./NodeJS/
```

O Swagger-jsdoc foi usado para gerar a documentação do swagger e o swagger-ui-express para gerar a interface

A validação de entrada ficou a cargo do pacote express-validator 

## Como Rodar

**Pre-requisitos**
- Docker
- Docker Compose
- Café ☕ (pq não?)

estando na pasta raiz 

```
docker-compose up
```

<p align="center">
<img align="center" width="250" height="170" src="https://media3.giphy.com/media/azGJUrx592uc0/giphy.gif">
</p>

O Docker irá subir 3 containers sendo API1, API2 e MongoDB 

Na Primeira inicialização o mongo fará o import collections para facilidar os testes e a compreensao das apis. Caso tenha algum problema com esse processo olhe na Sessão de troubleshooting

## APIs Publicadas

As Apis publicadas tem seus Swaggers publicados nos seguinte endereços

API1
```
https://squaremetercalculator-container.azurewebsites.net/swagger/index.html
```

API2
```
https://squaremeters-budget-api.herokuapp.com/api-docs/
```

## Troubleshooting
# Locadora De Veiculos 2024

<div align="center">

| <img width="60" src="https://user-images.githubusercontent.com/25181517/121405754-b4f48f80-c95d-11eb-8893-fc325bde617f.png"> | <img width="60" src="https://miro.medium.com/v2/resize:fit:300/0*cdEEkdP1WAuz-Xkb.png"> | <img width="60" src="https://raw.githubusercontent.com/altmann/FluentResults/master/resources/icons/FluentResults-Icon-64.png"> | <img width="60" src="https://rodrigoesilva.wordpress.com/wp-content/uploads/2011/04/sqlserver_sql_server_2008_logo.png"> |
|:---:|:---:|:---:|:---:|
| .NET Core | ASP.NET Core | FluentResults | Microsoft SQL Server |
||
| <img width="60" src="https://www.infoport.es/wp-content/uploads/2023/09/entity-core.png"> | <img width="60" src="https://api.nuget.org/v3-flatcontainer/dapper/2.1.35/icon"> | <img width="60" src="https://www.lambdatest.com/blog/wp-content/uploads/2021/03/MSTest.png"> | <img width="60" src="https://user-images.githubusercontent.com/25181517/184103699-d1b83c07-2d83-4d99-9a1e-83bd89e08117.png"> |
| EF Core | Dapper | MSTest | Selenium |

</div>

## Projeto
**Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024**

### Arquitetura
- DDD
- N-Camadas

### Stack:
- NET 8.0
- ASP.NET MVC
- Microsoft Identity
- Microsoft SQL Server
- Entity Framework Core
- AutoMapper
- Dapper
- FluentResults
- Selenium

### Inclui:
- Testes de Unidade
- Testes de Integra��o
- Testes e2e
- Autentica��o e Autoriza��o com Microsoft Identity
---

## Detalhes
O sistema foi desenvolvido para simplificar o gerenciamento das opera��es de uma locadora
de autom�veis, abrangendo funcionalidades essenciais como:

Cadastro de Funcion�rios, Clientes e Ve�culos: Administradores podem criar usu�rios para
empresas que utilizam a plataforma, al�m de gerenciar funcion�rios e ve�culos.

Configura��o de Alugu�is e Devolu��es: Permite o c�lculo de pre�os de alugu�is com base
em fatores como tipo de ve�culo, plano escolhido e taxas adicionais.

Gest�o de Taxas e Servi�os: Os clientes podem adicionar taxas e servi�os aos alugu�is,
com pre�os configur�veis por dia ou fixos, que impactam o custo final.

Controle de Devolu��es: O sistema registra a devolu��o dos ve�culos e aplica multas em
caso de atraso, al�m de considerar o custo de combust�vel para o c�lculo final.

Autentica��o e Autoriza��o: Implementado com Microsoft Identity, garantindo seguran�a no
gerenciamento de usu�rios e permiss�es.

O objetivo central � proporcionar uma gest�o eficiente para locadoras, melhorando a
experi�ncia tanto dos funcion�rios quanto�dos�clientes.


## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.
---
## Como Usar

#### Clone o Reposit�rio
```
git clone https://github.com/Kriegerl1/LocadoraDeVeiculos2024.git
```

#### Navegue at� a pasta raiz da solu��o
```
cd LocadoraDeVeiculos2024
```

#### Restaure as depend�ncias
```
dotnet restore
```

#### Navegue at� a pasta do projeto
```
cd LocadoraDeVeiculos.WebApp
```

#### Execute o projeto
```
dotnet run
```

# Documentação do Projeto

## 1. Introdução
Este documento descreve a arquitetura, implementação e funcionamento do projeto que envolve a criação, consulta, atualização e exclusão de entidades do domínio através de uma API RESTful, seguindo os padrões de Domain-Driven Design (DDD), utilizando Entity Framework, FluentValidation, AutoMapper, Mediator, Dependency Injection, padrão SOLID e testes unitários. A interface do cliente será desenvolvida em Angular TypeScript.

## 2. Arquitetura
O projeto segue o padrão DDD, que organiza o código em camadas de acordo com as responsabilidades do domínio, da aplicação, da infraestrutura e da interface do usuário. As camadas do projeto são as seguintes:

- **Domain**: Contém as entidades, agregados, serviços e eventos do domínio.
- **Application**: Camada responsável por orquestrar as operações de aplicação, utilizando os serviços do domínio.
- **Infrastructure**: Fornece implementações concretas para abstrações definidas nas camadas de domínio e aplicação. Inclui acesso ao banco de dados utilizando o Entity Framework, configurações de FluentValidation, injeção de dependências, mapeamento de objetos com AutoMapper e implementações de Mediator.
- **Presentation**: API RESTful que expõe os endpoints para interação com o sistema.

## 3. Tecnologias Utilizadas
- **Entity Framework**: Framework ORM para mapeamento objeto-relacional.
- **FluentValidation**: Biblioteca para validação de modelos.
- **AutoMapper**: Biblioteca para mapeamento de objetos.
- **Mediator**: Padrão de projeto para encapsular a lógica de negócios.
- **Dependency Injection**: Padrão para gerenciamento de dependências.
- **ASP.NET Core Web API**: Framework para construção de APIs RESTful.
- **SQL Server**: Banco de dados relacional para armazenamento de dados.
- **Angular TypeScript**: Framework para desenvolvimento de interfaces de usuário.

## 4. Implementação das Operações CRUD
- **Criação (POST)**: Permite a criação de novos registros no sistema.
- **Consulta por ID (GET)**: Recupera um registro específico pelo seu identificador único.
- **Consulta de Todos os Registros (GET)**: Recupera todos os registros de uma entidade.
- **Atualização (PUT)**: Atualiza um registro existente no sistema.
- **Exclusão (DELETE)**: Remove um registro do sistema.

## 5. Testes Unitários
Os testes unitários são escritos para cada classe de serviço e validador utilizando uma estrutura de testes apropriada, como MSTest ou NUnit, garantindo a cobertura adequada do código.

## 6. Validações com FluentValidation
As propriedades das entidades são validadas utilizando a biblioteca FluentValidation, garantindo a integridade dos dados.

## 7. Padrão SOLID
O projeto segue os princípios do SOLID (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion), visando criar um sistema mais modular, flexível e de fácil manutenção.

## 8. Integração com Angular TypeScript
Uma interface de usuário será desenvolvida em Angular TypeScript para interagir com a API RESTful, fornecendo uma experiência de usuário amigável e responsiva.

## Conclusão
Este documento fornece uma visão geral do projeto, incluindo sua arquitetura, tecnologias utilizadas e implementação das operações CRUD. O projeto segue as melhores práticas de desenvolvimento de software, garantindo qualidade, escalabilidade e manutenibilidade.

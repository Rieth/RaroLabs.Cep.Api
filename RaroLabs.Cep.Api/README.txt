### Arquitetura ###

# Arquitetura foi baseada em DDD, abaixo os ser�o apresentados os projetos e uma breve descri��o das suas responsabilidades.

RaroLabs.Cep.Api
- Cont�m a API para buscar o endere�o atrav�s do CEP.

RaroLabs.Cep.Api.Unit.Tests
- Cont�m os testes unit�rios dos controllers da API RaroLabs.Cep.Api.

RaroLabs.Cep.Domain
- Cont�m as entidades, servi�os e interfaces de dom�nio.

RaroLabs.Cep.Infrastructure
- Cont�m as implementa��es de reposit�rios, integra��es e cross cutting.


### Frameworks e Bibliotecas utilizadas ###
- Swagger: Tem como objetivo disponibilizar uma interface e documenta��o para facilitar o uso da API.
- Automapper: Tem como objetivo facilitar o mapeamento entre objetos semelhantes entre camadas.
- xUnit: Tem como objetivo possibilitar o desenvolvimento de testes unit�rios.
- Moq: Tem como objetivo facilitar a cria��o de mocks para utiliza��o nos testes unit�rios.



### Poss�veis Melhorias ###
- Framework para valida��es dos requests (Ex: FluentValidator);
- Estrat�gia de cache para endere�os/CEP j� buscados;
- Authentication/Authorization;
- Melhoria no tratamento de exceptions;
- RateLimit;
- Estrat�gia de Logs;
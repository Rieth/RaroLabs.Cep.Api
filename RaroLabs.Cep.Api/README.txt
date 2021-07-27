### Arquitetura ###

# Arquitetura foi baseada em DDD, abaixo os serão apresentados os projetos e uma breve descrição das suas responsabilidades.

RaroLabs.Cep.Api
- Contém a API para buscar o endereço através do CEP.

RaroLabs.Cep.Api.Unit.Tests
- Contém os testes unitários dos controllers da API RaroLabs.Cep.Api.

RaroLabs.Cep.Domain
- Contém as entidades, serviços e interfaces de domínio.

RaroLabs.Cep.Infrastructure
- Contém as implementações de repositórios, integrações e cross cutting.


### Frameworks e Bibliotecas utilizadas ###
- Swagger: Tem como objetivo disponibilizar uma interface e documentação para facilitar o uso da API.
- Automapper: Tem como objetivo facilitar o mapeamento entre objetos semelhantes entre camadas.
- xUnit: Tem como objetivo possibilitar o desenvolvimento de testes unitários.
- Moq: Tem como objetivo facilitar a criação de mocks para utilização nos testes unitários.



### Possíveis Melhorias ###
- Framework para validações dos requests (Ex: FluentValidator);
- Estratégia de cache para endereços/CEP já buscados;
- Authentication/Authorization;
- Melhoria no tratamento de exceptions;
- RateLimit;
- Estratégia de Logs;
# HungryUp
System for a democratically choice of a restaurant

Projeto .NET que segue padrões de TDD e DDD.
Injeção de Dependências são feitas em um assembly exclusivo desta forma a camada de apresentação desconhece implementações de business e repostory.
É utilizado a biblioteca Quarz para possibilitar o agendamento de execução de tarefas, neste caso, registrar na base de dados o restaurante mais votado antes do meio dia.
Também foi utilizada a biblioteca SignalR para que os usuários logados possam acompanhar em tempo real a votação dos seus colegas.
Entity Framework é o responsável por gerenciar a camada de repositório, desta forma, através do CodeFirst é possivel gerar todo o schema da base de dados.

Diversos pontos do sistema podem ser melhorados. Estruturalmente é necessário atualização da forma de autenticação para usar Identity.
A camada de apresentação precisa de estilização e uma melhor organização de scripts.
É possível aumentar o raio de ação dos testes, garantindo uma qualidade maior.
Funcionalmente, sistema poderia receber melhorias como envio de e-mail e notificações de browser no momento da conclusão da sessão de votação.
Também poderiam ser exibidas mais informações da votação como quem votou em cada restaurante.
Um ponto importante é a necessidade de criação de telas para que usuários novos possam se cadastrar.
É grande a necessidade de uma área administrativa para que possam ser controlados parâmetros do sistema como hora de finalização da sessão de votação por exemplo.
Ainda seria interessante a exibição de histórico de restaurantes escolhidos, lembrando que para casos de empate foi feita implementação para escolha aleatória.

A principal estrutura do sistema que tem seu ponto de partida um serviço pode ser fácilmente reutilizada em um novo projeto como um webAPI por exemplo.
Foram seguidos exemplos de códigos, principalmente dos MVP's Eduardo Pires e André Baltieri.

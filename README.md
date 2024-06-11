# ApiCrud

## Resumo
Esse projeto foi baseado no tutorial do canal CristianWillianDev onde foram ensinados os conceitos de Minimal API, ORM e CRUD.
Aplicação simples e com dicas para boas práticas na programação de sistemas.

## Conceitos aprendidos

Minimal API:
Permite a criação de API's http que utilizem menos recursos, sendo uma ótima opção para implementação de microserviços e aplicações que consumam o mínimo de dependências do ASP.NET Core, por exemplo.

ORM:
Técnica de mapeamento objeto-relacional que permite fazer uma relação dos objetos com os dados que os mesmos representam. Não é necessário a criação do banco de dados via SQL visto que todo o processo é feito através de código a partir do próprio ambiente de desenvolvimento com a ajuda do EntityFramework Core.

## Dicas de boas práticas

Utilizar a classe Record para transferências de dados específicos inclusive em uma classe DTO onde pode-se escolher quais dados serão vistos no front.
Utilizar o CancellationToken para métodos assíncronos evitando que o banco de dados fique travado caso uma requisição demore demais para ser atendida e seja cancelada.

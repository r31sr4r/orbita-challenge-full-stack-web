# Desafio Grupo A

## 🚀 Começando

### Decisão da arquitetura utilizada

Para a parte da API em .Net Core, a arquitetura utilizada foi baseada no modelo "Onion", de forma que uma camada é cliente dos serviços da camada imediatamente mais interna a ela, isto é, as dependências seguem sempre de fora para dentro.

### Lista de bibliotecas de terceiros utilizadas


* [Axios HTTP](https://axios-http.com/) - Cliente HTTP para simplificar as requisições à API
* [v-mask](https://www.npmjs.com/package/v-mask) - Biblioteca para aplicar máscaras nos campos texto


### O que você melhoraria se tivesse mais tempo

* **API**

    - Implementar quesitos de segurança tais como Autenticação/Autorização e protação das rotas.
        - Obs.: Na tela de login do Frontend foi inserido um campo **token**, contudo é apenas como exemplo para uma implementação futura. A API não está validando os acessos.
    -  Configurar mensagens de erro para fornecer informações suficientes somente para ajudar os usuários a relatar problemas;
    - Talvez implentar API gateway, por exemplo, ou um ponto de entrada dedicado para lidar com solicitações de autenticação.  
        

* **Frontend**

    - Com relação ao front acredito que caberia diversas melhorias, tendo em vista que o projeto em questão foi meu primeiro contato com Vue/Vuetify.
    
    - A primeira melhoria que faria seria componentizar as ações na página de Alunos, sendo que dividiria em pelo menos componentes de listagem, inclusão/edição e exclusão.
    

### Quais requisitos obrigatórios que não foram entregues

* Testes unitários
* Documentação da arquitetura de solução



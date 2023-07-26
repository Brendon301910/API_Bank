Stack:

```
C#
GraphQL
Postgres(via Docker)
```

(Pré-Reqs: **Docker Desktop** instalado.)<br/>
Na pasta do projeto, abra um terminal e crie a database no docker com o comando:

```
docker-compose up -d
```

O executável Para rodar a API está na pasta 'API_EXECUTAVEL', nome: 'API_bank.exe'.

## Para acessar o playground: 'http://localhost:5000/ui/playground'.

"DADO QUE eu consuma a API
QUANDO eu chamar a mutation sacar informando o número da conta e um valor válido
ENTÃO o saldo da minha conta no banco de dados diminuirá de acordo
E a mutation retornará o saldo atualizado."<br/>
"DADO QUE eu consuma a API
QUANDO eu chamar a mutation sacar informando o número da conta e um valor maior do que o meu saldo
ENTÃO a mutation me retornará um erro do GraphQL informando que eu não tenho saldo suficiente."

Primeiro, adicione uma ou mais contas no banco:

```
mutation addConta {
  addConta(conta: INSERIR_NUMERO, saldo: INSERIR_VALOR){
    conta
    saldo
  }
}
```

Agora, use a mutation sacar:

```
mutation sacar {
  sacar(conta: INSERIR_NUMERO, valor: INSERIR_VALOR)
  {
    conta
    saldo
  }
}
```

"DADO QUE eu consuma a API
QUANDO eu chamar a mutation depositar informando o número da conta e um valor válido
ENTÃO a mutation atualizará o saldo da conta no banco de dados
E a mutation retornará o saldo atualizado."

```
mutation depositar{
  depositar(conta: INSERIR_NUMERO, valor: INSERIR_VALOR)
  {
    conta
    saldo
  }
}
```

"DADO QUE eu consuma a API
QUANDO eu chamar a query saldo informando o número da conta
ENTÃO a query retornará o saldo atualizado."

```
query saldo{
  saldo(conta: INSERIR_NUMERO)
  {
    conta
    saldo
  }
}
```

Obs: Primeira vez que mexo com GraphQL, podem ter erros ou não boas práticas.
Obs2: Pensei em algumas maneiras com outras arquiteturas com camadas bem estabelecidas de aplicação, dominio, infraestrutura, persistência e WebApi, mas por conta de tempo hábil(fiz este projeto fora do horário comercial por conta do meu atual trabalho). Posso conversar sobre outras idéias posteriormente.

- https://github.com/killjoy2013/graphql-net-core-api-starter
- https://graphql.org/learn/
- Algumas APIS sobre GraphQL e transações bancárias.

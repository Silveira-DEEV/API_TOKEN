ASP.NET Web API com JWT + Console Client

Este projeto é composto por duas partes:

1. MinhaApiJwt – Uma Web API construída com ASP.NET que implementa autenticação usando JSON Web Token (JWT).
2. ClientConsole – Um cliente em linha de comando (console app) que permite registrar usuários, autenticar e interagir com a API.

Tecnologias Utilizadas

- ASP.NET Core Web API
- JSON Web Token (JWT)
- Console Application
- JSON como base de dados local

Funcionalidades da API

- `POST /auth/login` – Gera um token JWT com base em um nome de usuário e senha.
- `POST /usuarios/cadastrar` – Registra um novo usuário.
- `GET /usuarios/listar` – Lista todos os usuários.

Console Client

A aplicação de console permite:

- Inserir usuários manualmente via terminal.
- Enviar requisições para a API.

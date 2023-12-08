# API para teste backend de pedidos

## Instalação
Clone o repositório para a sua máquina local usando o Git:
```bash
https://github.com/lipilemos/TEST_API_Pedidos.git
```

## Projeto de API .NET Core6 com EF Core e Migrações + Test
Este é um projeto de API .NET Core 6 que utiliza EF Core para interagir com um banco de dados `SQL ou inMemory`. O projeto inclui swagger e migrações para facilitar a evolução do esquema do banco de dados.

### Pacotes adicionais :
Mapper, Validation, Mock

## Configurações Necessárias
Antes de executar o projeto, certifique-se de ter as seguintes configurações:

# 1. Banco de Dados + Migrations/ EFCore InMemory 
O projeto utiliza o Entity Framework Core para interagir com um banco de dados. Certifique-se de ter um servidor de banco de dados SQL Server configurado. Você precisará de uma string de conexão válida no arquivo appsettings.json. Certifique-se de aplicar as migrações para criar o esquema do banco de dados. Abra o terminal na pasta do projeto e execute os seguintes comandos:
```bash
enable-migrations
add-migration Initial
```

### Acessar a API:
Acesse a API no seu navegador ou utilizando uma ferramenta como Postman em https://localhost:7049.

### Contato
Se você tiver alguma pergunta ou sugestão, sinta-se à vontade para entrar em contato:

Felipe Lemos - [lipe.dev@outlook.com.br](mailto:lipe.dev@outlook.com.br)
Link para o projeto: [https://github.com/lipilemos/TEST_API_Pedidos.git](https://github.com/lipilemos/TEST_API_Pedidos.git)

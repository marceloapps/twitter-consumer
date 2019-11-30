# Twitter Consumer

Projeto desenvolvido em .netCore 3.0 para consumir posts do Twitter e gravar no banco de dados mongodb, de acordo com as hashtags:
#openbanking, #apifirst, #devops, cloudfirst, #microservices, #apigateway, #oauth, #swagger, #raml, #openapis

## Inicialização

Clonar o repositório TwitterConsumer para a máquina local, e abrir com o Visual Studio 2019 (ou VS Code).

### Pré requisitos

[VS 2019](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&rel=16)
[SDK do dot.net core 3.0](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.0.101-windows-x64-installer)
[Docker desktop](https://hub.docker.com/?overlay=onboarding)
MongoDB 4.2.1: 
* docker pull mongo:4.2.1
* docker run -d -p 27017-27019:27017-27019 --name mongodb mongo:4.2.1
* docker start mongodb
	
Para criar o banco de dados que será usado para gravar os posts do Twitter:
* docker exec -it mongodb mongo (abrir shell do mongodb)
* use TweetsDB
* db.Collections.Add("tweets")

### Instalação

Com o projeto aberto, usar a opção "publish" do Visual Studio.
Se na máquina houver o .net core runtime, pode selecionar a opção "framework dependent". Caso contrário, selecionar "autosuficient".
Caso deseje, copie os arquivos gerados na pasta \bin\Release\netcoreapp2.2\publish a um local definitivo.

## Execução

Para publicação dependente de framework:
* dotnet TwitterConsumer.dll

Para publicação auto-suficiente:
* executar o arquivo TwitterConsumer.exe

## Built With

* [.NetCore 3.0](https://docs.microsoft.com/pt-br/dotnet/core/about) - Framework utilizado
* [TweetInvi](https://github.com/linvi/tweetinvi) - API do Twitter para consumir os posts
* [MongoDB.Driver](https://docs.mongodb.com/ecosystem/drivers/csharp/) - Utilizado para criar conexão com mongodb

## Versioning

v1.0.0

## Autor

* **Marcelo Arakaki** - [marceloapps](https://github.com/marceloapps)

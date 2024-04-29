# Posts API 
.NET 8 API that enables CRUD operations on Posts, it uses Dapper and connects to Postgres.

appsettings.json contains configuration for Postgres connection string. The database must exist prior to running, next versions should include a way to containarize this database for easy development.


## For local development 
 - Install [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
 - for Database development install [Postgres SQL](https://www.postgresql.org/)


## Run the app

    dotnet run
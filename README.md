# Posts API 
API that enables CRUD operations on Posts, it uses Dapper and connects to Postgres.

## For local development 
 - Install [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)


### Database development 
 - Download and install [Postgres SQL.](https://www.postgresql.org/)
 - Download and install [Liquibase.](https://docs.liquibase.com/start/install/home.html)
 - Update files appsettings.json and liquibase.propertiesfile to your target database. 

## Run the app
    dotnet run

## Test the app
The following command will run all unit tests.

    dotnet test 


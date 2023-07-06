set dotenv-load

default:
    just dev

dev:
    dotnet run --environment "Development"

run:
    dotnet run

ef +rest:
    dotnet ef {{rest}}

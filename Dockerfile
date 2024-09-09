# Usar uma imagem de construção com SDK para compilar o código
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env
WORKDIR /app

# Copiar csproj e restaurar as dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar os arquivos do projeto e construir a aplicação para produção
COPY . ./
RUN dotnet publish -c Release -o out

# Gerar a imagem de runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /app
COPY --from=build-env /app/out .

# Definir comando para rodar a aplicação
ENTRYPOINT ["dotnet", "YourApplication.dll"]

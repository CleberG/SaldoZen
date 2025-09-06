# 1. Imagem base para a execução final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# 2. Imagem de build para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo da solução e os arquivos de projeto primeiro
COPY ["SaldoZen.sln", "."]
COPY ["SaldoZen/SaldoZen.csproj", "SaldoZen/"]
COPY ["SaldoZen.Domain/SaldoZen.Domain.csproj", "SaldoZen.Domain/"]
COPY ["SaldoZen.Infraestrutura/SaldoZen.Infraestrutura.csproj", "SaldoZen.Infraestrutura/"]

# Restaura todas as dependências da solução
RUN dotnet restore "SaldoZen.sln"

# Copia o resto do código fonte
COPY . .

# 3. Publica o projeto principal
FROM build AS publish
# O WORKDIR /src é herdado do estágio anterior
RUN dotnet publish "SaldoZen/SaldoZen.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Estágio final, criando a imagem final a partir da base
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SaldoZen.dll"]